﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autofac; 

namespace BLL.Infrastructure
{
    /// <summary>
    /// Engine
    /// </summary>
    public class KptEngine : IEngine
    {
        #region Fields

        private ContainerManager _containerManager;
        private ContainerBuilder _containerBuilder;
        
        #endregion

        #region Utilities

        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="config">Config</param>
        protected virtual void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            
            //dependencies
            var typeFinder = new WebAppTypeFinder(); 
            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            //register dependencies provided by other assemblies
            var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var drInstances = new List<IDependencyRegistrar>();
            foreach (var drType in drTypes)
                drInstances.Add((IDependencyRegistrar) Activator.CreateInstance(drType));
            //sort
            drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            foreach (var dependencyRegistrar in drInstances)
                dependencyRegistrar.Register(builder, typeFinder);

            var container = builder.Build();
            this._containerManager = new ContainerManager(container);
            _containerBuilder = builder;
            //set dependency resolver
            // DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
         
        #endregion

        #region Methods

        /// <summary>
        /// Initialize components and plugins in the  environment.
        /// </summary>
        /// <param name="config">Config</param>
        public void Initialize()
        {
            //register dependencies
            RegisterDependencies();        

        }

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
		{
            return ContainerManager.Resolve<T>();
		}

        /// <summary>
        ///  Resolve dependency
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }
        
        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public T[] ResolveAll<T>()
        {
            return ContainerManager.ResolveAll<T>();
        }

		#endregion

        #region Properties

        /// <summary>
        /// Container manager
        /// </summary>
        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }

        public ContainerBuilder ContainerBuilder
        {
            get
            {
                return _containerBuilder;
            }

            set
            {
                _containerBuilder = value;
            }
        }

        #endregion
    }
}
