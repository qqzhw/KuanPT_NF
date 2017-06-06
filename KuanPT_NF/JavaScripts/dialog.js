/*  Dialog ( jQuery extension ) Author:luotao */
/*  ciwong.dialog.v1.0
/* 2012/6/5   一、修复IE8 ，IE7 dlg.msg下面提示框 有黑边问题，  二、拖动框onmouseup 改为bind方法   */
/* 2012/8/16 添加 dlg.Msg.Lod方法（loading方法）; 需要用dlg.clsLod("ID") 清除 */
/* 2012-12-24 添加方法 dlg.Iframe() */
/* 2012-12-29 添加方法 窗口固定开关和父窗口滚动条屏蔽开关 */

var dlg={
//元素
element:function(){
	this._title = "标题";
	this._content = "内容";
	this._fn1 = function(){};
	this._fn2 = function(){};
	this._width = 350;
	this._height = 200;
	this._mask = $('<div style="position:fixed; _position:absolute; display:none; top:0px; left:0px; _top:expression(eval(document.documentElement.scrollTop)); _left:expression(eval(document.documentElement.scrollLeft)); background:#000; z-index:999; filter:alpha(opacity=20); opacity:0.2; width:100%;" id="mask"><iframe scrolling="no" style="filter:alpha(opacity=0); opacity:0; width:100%; height:100%; display:none; *display:block; " ></iframe></div>')
	this._obj = $('<div class="box_dialog"></div>');
	this._head = $('<h1 class="dialog_title"></h1>');
	this._cont = $('<div class="dialog_content"></div>');
	this._ifra = $('<iframe class="dialog_iframe" scrolling="no"  frameborder="0"  src=""></iframe>');
	this._text = $('<span class="dialog_txt"></span>');
	this._foot = $('<div class="dialog_bottom"></div>');
	this._info = $('<i class="ico_info"></i>');
	this._aler = $('<i class="ico_aler"></i>');  
	this._ques = $('<i class="ico_ques"></i>');
	this._erro = $('<i class="ico_erro"></i>'); 
	this._corr = $('<i class="ico_corr"></i>');
},
//提示信息
Msg:{ 
	   elem:function(){
		    this._fn = function(){};
			this._mask = $('<div style="position:fixed; _position:absolute; display:none; top:0px; left:0px; _top:expression(eval(document.documentElement.scrollTop)); _left:expression(eval(document.documentElement.scrollLeft)); z-index:999; width:100%; filter:alpha(opacity=0); opacity:0; background:#fff;" id="mask0"><iframe scrolling="no" style="filter:alpha(opacity=0); opacity:0; width:100%; height:100%; display:none; *display:block;" ></iframe></div>')
			this._obj = $('<div class="box_sugg"></div>');
			this._left = $('<b class="sugg_left"></b>');
			this._right = $('<b class="sugg_right"></b>');
			this._con = $('<div class="sugg_con"></div>');
			this._incon = $('<span class="sugg_in_con"></span>');
			this._info = $('<i class="ico_info"></i>');
			this._erro = $('<i class="ico_erro"></i>');  
			this._corr = $('<i class="ico_corr"></i>');
			this._load = $('<i class="ico_load"></i>');
		  },
	  ply:function(c,fn,n){
/*		    if($(".box_sugg").length > 0){
				return false;
			}*/
			var e = new this.elem();
			$.extend(e,{_fn:fn});			
			var obj = e._obj;
			var mask = e._mask;
			obj.append(e._left);
			obj.append(e._con);
			obj.append(e._right);
			switch(n){
			   case 1: e._con.append(e._info);
			   break;			   
			   case 2: e._con.append(e._erro);
			   break;			   
			   case 3: e._con.append(e._corr);
			   break; 		   
			   case 4: e._con.append(e._load);
			   break; }
			e._con.append(e._incon);
			e._incon.append(c);
			$("body").append(mask);
			$("body").append(obj);
			if( $.browser.msie && $.browser.version == 6 ){
			   var t = $(document).scrollTop() + ($(window).height() - obj.height())/2;
			}else{
			   var t = ($(window).height() - obj.height())/2;				
			}
			var l = ($(window).width() - obj.width())/2;
			var c = function(){
				var t = $(document).scrollTop() + ($(window).height() - obj.height())/2; 
				var l = ($(window).width() - obj.width())/2;
				obj.css({"top":t,"left":l});
				mask.css({"top":t,"left":l});
			};					
					
			if( $.browser.msie && $.browser.version <= 6 ){     //IE6 fix hack
			    $(window).bind("scroll",function(){ c() });
			}
			if($.browser.msie && $.browser.version < 9 ){		//IE9以下无淡入淡出效果
				if(n == 4){				//打开loading
					obj.attr("id",fn);
					mask.attr("id",fn+"mask0");
			    	obj.css({top:t,left:l}).show();
				}else{
					obj.css({top:t,left:l}).show();
					setTimeout( function(){ 
						  if( $.browser.msie && $.browser.version == 6 ){    //用于解决IE6点击mask后会，input，textarea无法获得焦点
							  var t_inp = $("<input type='text'/>");
							  obj.append(t_inp);
							  t_inp.focus();
							  t_inp.remove();
						  };
						  obj.remove(); mask.remove(); e._fn(); 
					},2500)
				}
			}else{											 //IE9及W3C有淡入淡出效果
				if(n == 4){				//打开loading
					obj.attr("id",fn);
					mask.attr("id",fn+"mask0");
			    	obj.css({top:t,left:l}).show();
				}else{
					obj.css({top:t,left:l,opacity:"0"}).show();	
					obj.animate({opacity:"1"},400,function(){ setTimeout( function(){ obj.animate({opacity:"0"},400,function(){ obj.remove(); mask.remove();  e._fn(); })},2500) });
				}
			}
			mask.css({"height":$(obj).height(),"width":$(obj).width(),"top":$(obj).offset().top,"left":$(obj).offset().left}).show();	
	   },
	  //普通信息
      Inf:function(c,fn){
		  this.ply(c,fn,1);
	  },
	  //错误信息
      Err:function(c,fn){
		  this.ply(c,fn,2);
	  },
	  //正确信息
      Cor:function(c,fn){
		  this.ply(c,fn,3);
	  },
	  //loading
      Lod:function(c,id){
		  if(document.getElementById(id)){
		}else{
		  	this.ply(c,id,4);
		  }
	  }  
},	
//警告
Alert:function(t,c,f1,f2){                                                        
		var e = new this.element();
		$.extend(e,{_title:t,_content:c,_fn1:f1,_fn2:f2});
		var btn_0 = this.btn(e._obj,e._mask,"close","关闭",e._fn2,true);
		var btn_1 = this.btn(e._obj,e._mask,"btn_yes","确定",e._fn1,true);
		e._obj.append(e._head);
		e._obj.append(e._cont);		
		e._obj.append(e._foot);	
		e._obj.append( btn_0 );		
		e._cont.append( e._aler );
		e._cont.append( e._text );			
		e._foot.append(btn_1);
		e._head.html(e._title);
		e._text.html(e._content);
		this.opn(e._obj,e._mask);	
		this.drag(e._obj,e._head);
},	
//确认	
Confirm:function(t,c,f1,f2){                     
		var e = new this.element();
		$.extend(e,{_title:t,_content:c,_fn1:f1,_fn2:f2});
		var btn_0 = this.btn(e._obj,e._mask,"close","关闭",e._fn2,true);
		var btn_1 = this.btn(e._obj,e._mask,"btn_yes","确定",e._fn1,true);
		var btn_2 = this.btn(e._obj,e._mask,"btn_no","取消",e._fn2,true);
		e._obj.append(e._head);
		e._obj.append(e._cont);		
		e._obj.append(e._foot);		
		e._obj.append( btn_0 );		
		e._cont.append( e._ques );
		e._cont.append( e._text );			
		e._foot.append(btn_1);
		e._foot.append(btn_2);			
		e._head.html(e._title);
		e._text.html(e._content);
		this.opn(e._obj,e._mask);	
	    this.drag(e._obj,e._head)
},	
//消息	
Infor:function(c,f1){                                                          
		var e = new this.element();
		$.extend(e,{_title:"消息",_content:c,_fn1:f1});
		var btn_0 = this.btn(e._obj,e._mask,"close","关闭",e._fn2,true);
		var btn_1 = this.btn(e._obj,e._mask,"btn_yes","确定",e._fn1,true);
		var btn_2 = this.btn(e._obj,e._mask,"btn_no","取消",e._fn2,true);	
		e._obj.append(e._head);
		e._obj.append(e._cont);		
		e._obj.append(e._foot);		
		e._obj.append( btn_0 );		
		e._cont.append( e._info );
		e._cont.append( e._text );			
		e._foot.append(btn_1);	
		e._foot.append(btn_2);		
		e._head.html(e._title);
		e._text.html(e._content);
		this.opn(e._obj,e._mask);	
	    this.drag(e._obj,e._head)
},	
//错误	
Error:function(c,f1){                                                            
		var e = new this.element();		
		$.extend(e,{_title:"错误",_content:c,_fn1:f1});
		var btn_0 = this.btn(e._obj,e._mask,"close","关闭",e._fn2,true);
		var btn_1 = this.btn(e._obj,e._mask,"btn_yes","确定",e._fn1,true);
		var btn_2 = this.btn(e._obj,e._mask,"btn_no","取消",e._fn2,true);	
		e._obj.append(e._head);
		e._obj.append(e._cont);		
		e._obj.append(e._foot);		
		e._obj.append( btn_0 );		
		e._cont.append( e._erro );
		e._cont.append( e._text );			
		e._foot.append(btn_1);
		e._foot.append(btn_2);			
		e._head.html(e._title);
		e._text.html(e._content);
		this.opn(e._obj,e._mask);	
	    this.drag(e._obj,e._head)
},	
//通用
Common:function(t,c,w,f1,f2){            
		var e = new this.element();
		$.extend(e,{_title:t,_content:c,_width:w,_fn1:f1,_fn2:f2});
		var btn_0 = this.btn(e._obj,e._mask,"close","关闭",e._fn2,true);
		var btn_1 = this.btn(e._obj,e._mask,"btn_yes","确定",e._fn1,true);
		var btn_2 = this.btn(e._obj,e._mask,"btn_no","取消",e._fn2,true);		
		e._obj.append(e._head);
		e._obj.append(e._cont);		
		e._obj.append(e._foot);		
		e._obj.append( btn_0 );	
		e._foot.append(btn_1);
		e._foot.append(btn_2);			
		e._head.html(e._title);
		e._cont.html(e._content);
		e._obj.css("width",e._width);
		this.opn(e._obj,e._mask);
		this.drag(e._obj,e._head)        
},
//通用不带按钮
Com:function(id,t,c,w,f1){
		var e = new this.element();
		$.extend(e,{_title:t,_content:c,_width:w,_fn1:f1});
		/*var op = dlg.option(arguments);				//查找参数中是否有传对象	并用对象方法传值
		if(op){
			dlg.fix = op.fix;
			dlg.outScroll = op.outScroll;
			$.extend(e,{
				_id: op.id,
				_title:op.title,
				_content:op.content,
				_width:op.width,
				_fn1:op.fn
			});			
		}*/
		var btn_0 = this.btn(e._obj,e._mask,"close","关闭",e._fn1,false);	
		e._obj.append(e._head);
		e._obj.append(e._cont);
		e._obj.append( btn_0 );	
		e._head.html(e._title);
		e._cont.html(e._content);
		e._obj.css("width",e._width);
		e._obj.attr("id",id);
		e._mask.attr("id",id+"Mask");
		this.opn(e._obj,e._mask);
		this.drag(e._obj,e._head);
},

//窗口固定开关（默认不打开）
fix : false,

//屏蔽父窗口html、body滚动条 
outScroll : false,

//页面地址不带按钮
Url:function(id,t,c,w,h,f1,s){
		var e = new this.element();
		$.extend(e,{_title:t,_content:c,_width:w,_height:h,_fn1:f1});
		var btn_0 = this.btn(e._obj,e._mask,"close","关闭",e._fn1,false);	
		e._obj.append(e._head);
		e._obj.append(e._ifra);
		e._obj.append( btn_0 );	
		e._head.html(e._title);
		e._ifra.attr({"src":e._content,"width":w,"height":h});
		if(s){	
			e._ifra.attr({"scrolling":"auto"});
		}
		e._obj.css("width",e._width);
		e._obj.attr("id",id);
		e._mask.attr("id",id+"Mask");
		this.opn(e._obj,e._mask);
		this.drag(e._obj,e._head) 
},
//iframe 弹框
Iframe:function(id,t,c,w,h,f1,autohi){
	    var e = new this.element();
		$.extend(e,{_title:t,_content:c,_width:w,_height:h,_fn1:f1});
		var btn_0 = this.btn(e._obj,e._mask,"close","关闭",e._fn1,false);	
		e._obj.append(e._head);
		e._obj.append(e._ifra);
		e._obj.append(btn_0);	
		e._head.html(e._title);	
		e._obj.css({"width":e._width});
		e._obj.attr("id",id);
		e._mask.attr("id",id+"Mask");
		var getIframe = function(){						//得到iframe
			var arr = document.getElementById(id).getElementsByTagName('*');
			var iframe = null;
			for(var i=0,l=arr.length; i<l; i++){				
				if( arr[i].className == 'dialog_iframe'){
					iframe = arr[i];
					break;
				}
			}
			return iframe;
		}
		if(autohi){											//自适应高度
			e._ifra.attr({"src":e._content,"width":w,"height":h});
			this.opn(e._obj,e._mask);
			this.drag(e._obj,e._head);	
			var iframe = getIframe();						
			if($.browser.msie && $.browser.version <= 6 ){				//IE6 bug 重新加载一次
               setTimeout(function(iframe){  return function(){
				    var temp = iframe.getAttribute("src");
					iframe.setAttribute("src",temp);
			   }}(iframe), 100);
            }
			
			var time = setInterval(function(iframe){
				return function(){
				var _h = h;
				if(iframe){
					try{
						if(iframe.contentWindow){				 //IE 大部分浏览器  chrome在本地测试会有问题，是因为chrome把本地iframe当做跨域页面，在真实环境不会有此问题！
							_h = iframe.contentWindow.document.body.offsetHeight;
						}else{								//W3C
							_h = iframe.contentDocument.body.offsetHeight;						
						}
					}catch(e){}
								
					if(_h != h){
						iframe.setAttribute("height",_h);
						h = _h;
					}
				}else{
					clearInterval(time);
				}
			}}(iframe),500)
		}else{												//带滚动条，固定高度、固定位置fixed;	
			e._ifra.attr({"src":e._content,"width":w,"height":h,"scrolling":"auto"});			
			dlg.fix = true;
			dlg.outScroll = true;
			this.opn(e._obj,e._mask);
			this.drag(e._obj,e._head);
						
			var iframe = getIframe();
			if($.browser.msie && $.browser.version <= 6 ){			//IE6 bug 重新加载一次
               setTimeout(function(iframe){  return function(){
				    var temp = iframe.getAttribute("src");
					iframe.setAttribute("src",temp);
			   }}(iframe), 100);
            }
		}
},
//按钮
btn:function(obj,mask,cla,txt,fn,g){		  	
		return $("<a href='javascript:;'></a>").attr({"class":cla,"title":txt}).html(txt).on("click",function(){ fn(); if(g == true){ dlg._cls(obj,mask)} })
},
//打开对话框
opn:function(obj,mask){
		if(dlg.outScroll == true){						 //设置是否屏蔽父窗口滚动条
			$('html,body').css('overflow','hidden')
		}   
		$("body").append( mask);
		$("body").append( obj);
		mask.height($(window).height());
			
		if(dlg.fix){
		//固定窗口			
				if($.browser.msie && $.browser.version <= 6 ){
				   var t = $(document).scrollTop() + ($(window).height() - obj.height())/2;
				   var t0 = ($(window).height() - obj.height())/2;
				}else{
				   var t = ($(window).height() - obj.height())/2;
				}
				if( t < 0){ t = 0 };
				var l = ($(window).width() - obj.width())/2;
				if( this.animation() == 0 ){                  																							//无动画  
					var stl = obj.attr('style')+'; position:fixed; left:'+l+'px; top:'+t+'px; _position:absolute; _top:expression(eval(document.documentElement.scrollTop +'+t0+'))';
					obj.attr('style',stl);
					obj.attr('style',stl);
					mask.show(); obj.show(); 
				}; 
				if( this.animation() == 1 ){ 																											 //动画1	  固定方法不支持IE6
					obj.css({top: t - 50+"px",left:l +"px",opacity:"0",'position':'fixed'}).show(); mask.fadeIn(200,function(){ obj.animate({top:t,opacity:"1"},300)});	
				} 
				if( this.animation() == 2 ){    																										 //动画2  固定方法不支持IE6
					var _t = $(document).scrollTop() + $(window).height()/2; 		
					var _l = $(window).width()/2;
					var _w = obj.width();
					var _h = obj.height();
					var box = $('<div style="background:#fff; position:fixed; z-index:1001; filter:alpha(opacity=80); opacity:0.8; "></div>')
					box.css({width:"0px",height:"0px",top:_t,left:_l});		
					$("body").append(box);
					mask.fadeIn(200,function(){ box.animate({width:_w,height:_h,top:t,left:l},300,function(){ box.remove(); obj.css({top:t,left:l,position:'fixed'}).show(); }) });
				}	
				$(window).bind("resize",function(){	
					var l = ($(window).width() - obj.width())/2;				
					if($.browser.msie && $.browser.version <= 6){
						obj.css("left",l);						
						var t = ($(window).height() - obj.height())/2;			
						var stl = obj.attr('style')+'; top:expression(eval(document.documentElement.scrollTop +'+t+'))';
						obj.attr('style',stl);
					}else{
						var t = ($(window).height() - obj.height())/2; 				      
						if( t <= 0){ t = 0 };
						obj.css({"top":t+"px","left":l+"px"});
					}
					mask.height($(window).height());
					if($(window).width() < 986 ){ mask.width("986px") }else{ mask.width("100%")  }
				})
		//固定窗口
		
		}else{
				var t = $(document).scrollTop() + ($(window).height() - obj.height())/2; 
				if( t < 0){ t = 0 };
				var l = ($(window).width() - obj.width())/2;
				if( this.animation() == 0 ){ obj.css({"top":t+"px","left":l+"px"}); mask.show(); obj.show();  };  																   //无动画
				if( this.animation() == 1 ){ obj.css({top: t - 50+"px",left:l +"px",opacity:"0"}).show(); mask.fadeIn(200,function(){ obj.animate({top:t,opacity:"1"},300); });	}  //动画1
				if( this.animation() == 2 ){    																																	//动画2
					var _t = $(document).scrollTop() + $(window).height()/2; 		
					var _l = $(window).width()/2;
					var _w = obj.width();
					var _h = obj.height();
					var box = $('<div style="background:#fff; position:absolute; z-index:1001; filter:alpha(opacity=80); opacity:0.8; "></div>')
					box.css({width:"0px",height:"0px",top:_t,left:_l});		
					$("body").append(box);
					mask.fadeIn(200,function(){ box.animate({width:_w,height:_h,top:t,left:l},300,function(){ box.remove(); obj.css({top:t,left:l}).show() }) });
				}	
				$(window).bind("resize",
				function(){
					var t = $(document).scrollTop() + ($(window).height() - obj.height())/2; 				      
					if( t < 0){ t = 0 };
					var l = ($(window).width() - obj.width())/2;
					obj.css({"top":t+"px","left":l+"px"});
					mask.height($(window).height());
					if($(window).width() < 986 ){ mask.width("986px") }else{ mask.width("100%")  }
					
				})
		}
},	
//关闭对话框
_cls:function(obj,mask){
	var collectGarbage =  function (element) {				//iframe内存回收
        var ifo = null;
			ifo = element;
        if (ifo) {
            try {
                if($.browser.msie) {
                    dc = ifo.contentWindow.document;
                }else{
                    dc = ifo.contentDocument;
                }
                if(dc){
                    dc.write('');
                    dc.clear();
                    dc.close();
                }
            }catch(e){ }
            ifo.setAttribute("src", "javascript:false");
            ifo.parentNode.removeChild(ifo);
            ifo = null;
        }
        if ($.browser.msie) {
            CollectGarbage();
            setTimeout(function () { CollectGarbage(); },1);
        }
    }
	
	if(dlg.outScroll == true){						 			//还原屏蔽的父窗口滚动条
			$('html,body').css('overflow','');
	}
	
	var eles = $(obj).find("iframe");
	for(var i = 0,l = eles.length; i<l; i++){
		if(eles[i].tagName == "IFRAME"){
			collectGarbage(eles[i]);
		}
	}
	
	if( $.browser.msie && $.browser.version <= 6 ){    //用于解决IE6点击mask后会，input，textarea无法获得焦点
		var t_inp = $("<input type='text'/>");
		obj.append(t_inp);
		t_inp.focus();
		t_inp.remove();
    };
	
	if( this.animation() == 0 ){ obj.css("top",""); mask.remove(); obj.remove();  }; //无动画
	if( this.animation() == 1 ){                                 //动画1
		var m = obj.position().top + 50;
		obj.animate({top:m,opacity:"0"},300,function(){ obj.hide(); mask.fadeOut(200,function(){ mask.remove(); obj.remove() })});			
	}; 
	if( this.animation() == 2 ){                                 //动画2
		var _t = $(document).scrollTop() + $(window).height()/2; 		
		var _l = $(window).width()/2;
		var box = $('<div style="background:#fff; position:absolute; z-index:1001; filter:alpha(opacity=80); opacity:0.8;"></div>')
		box.css({width:obj.width(),height:obj.height(),top:obj.css("top"),left:obj.css("left")});
		$("body").append(box);
		obj.hide();
		box.animate({width:"0",height:"0",top:_t,left:_l},300,function(){ box.remove(); mask.fadeOut(200,function(){ mask.remove(); obj.remove() })});	
	}
	$(window).unbind("resize");
	dlg.fix = false;
	dlg.outScroll = false;
	
	
},	
//对外关闭对话框
cls:function(id){	
	  var obj = $("#"+id);
	  var mask = $("#"+id+"Mask");
	  this._cls(obj,mask);
},
//对外关闭loding对话框
clsLod:function(id){	
	  var obj = $("#"+id);
	  var mask = $("#"+id+"mask0");
	  obj.remove();
	  mask.remove();
},
//从iframe关闭父级里弹框方法
clo:function(id){
	window.parent.dlg.cls(id);
},
//导步加载情况下页面居中
center:function(id){
	if( document.getElementById(id) ){
	var obj = $("#"+id);
	var t = $(document).scrollTop() + ($(window).height() - obj.height())/2; 
	if( t < 0){ t = 0 };
	var l = ($(window).width() - obj.width())/2;
	obj.css({"top":t+"px","left":l+"px"});
	}
},
//全局动画控制
animation:function(){
	if($.browser.msie && $.browser.version == 6 ){
		return 0;
	}else{
		return 2;
	}
},
option:function(args){
	for(var i=0,l=args.length; i<l; i++){
		if(typeof(args[i]) == "object"){
			return args[i];
		}
	}
	return false
},
//拖拽
drag:function(o,t){
	var m_x,m_y;
	var obj = $(o);
	var hand = $(t);
	//固定窗口
	if(dlg.fix){
		var vbox = $('<div class="box_dashed" style="position:fixed; _position:absolute;"><div class="in_dashed"></div></div>');
	}else{
		var vbox = $('<div class="box_dashed"><div class="in_dashed"></div></div>');
	}
	//固定窗口
	hand.on("mousedown",function(e){
		vbox.css({"left":$(obj).css("left"),"top":$(obj).css("top"),"width":$(obj).css("width"),"height":$(obj).css("height")});	
        $("body").append(vbox);
		e = e|| window.event;		
		m_x = e.clientX - obj.offset().left;
		m_y = e.clientY - obj.offset().top;
        if( document.body.setCapture ){
		        document.body.onmousemove = move;
				document.body.onmouseup = end;
				document.body.setCapture();
		   }else{
	   			document.addEventListener("mousemove",move,false);
			    document.addEventListener("mouseup",end,false) 
		   }
	});
	var move = function(e){
		e = e|| window.event;
		var x = e.clientX - m_x;
		var y = e.clientY - m_y;
		//固定窗口
		if(dlg.fix){
			x = e.clientX - m_x - $(document).scrollLeft();
			y = e.clientY - m_y - $(document).scrollTop();
			if($.browser.msie && $.browser.version <= 6){
				x = e.clientX - m_x;
				y = e.clientY - m_y;
			}
		}
		//固定窗口
	    var r = $(document).width() - obj.outerWidth(true);
	    var b = $(document).height() - obj.outerHeight(true);
		if(x<0){x=0}else {if(x>r){x = r}};
		if(y<0){y=0}else {if(y>b){y = b}};		
		vbox.css({"left":x +"px","top":y +"px"});
		window.getSelection ? window.getSelection().removeAllRanges() : document.selection.empty(); //防止选择文字
	};
	var end = function(){
		vbox.remove();	
     	obj.css({"left":vbox.css("left"),"top":vbox.css("top")})
		//固定窗口
		if(dlg.fix){
			if($.browser.msie && $.browser.version <= 6){				
				t = parseInt(vbox.css("top")) - $(document).scrollTop();
				if(t <=0 ){ t = 0; obj.css('top',$(document).scrollTop()) }
				var stl = obj.attr('style')+'; _top:expression(eval(document.documentElement.scrollTop + '+t+'))';
				obj.attr('style',stl)
			}
		}
		//固定窗口
	    if(document.body.setCapture){ 		
		       document.body.onmousemove = null;
			   document.body.onmouseup = null;
			   document.body.releaseCapture();
		   }else{	
			   document.removeEventListener("mousemove",move,false);
			   document.removeEventListener("mouseup",arguments.callee,false) 
		   }
	}	
}
};
function closeNewYearAlert() {
        $("#newyear").hide();
        $(".top .bg_top").css({ top: 0 });
        $(".wrap").css({ marginTop: 0 });
    }