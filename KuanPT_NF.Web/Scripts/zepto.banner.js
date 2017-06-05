(function($, window, document, undefined) {

    $.fn.banner = function(parameter) {

        //传入参数
        parameter = parameter || {};

        //默认参数
        var defaults = {
            isBtn: true, //是否有左右按钮
            isAutoMove: true, //是否自动滑动
            autoMoveTime: 2000, //自动轮播速度
            nextImgSpeed: 500, //轮播切换快慢
            numStyle: true, //num是否需要数字 
            bannerWidth: 520 //banner的宽度
        };

        //真正参数  
        var options = $.extend({}, defaults, parameter);

        //插件主体
        return this.each(function() {      


            //全局变量
            var $this = $(this);
            var i = 0;
            var isMoving = false; //是否正在动画中

            /*更新bannerWidth*/
            $(window).resize(function() {
                options.bannerWidth = $('.banner .img ul li a img').width();
            });

            //初始化.img	
            var clone = $this.find(".img ul li").first().clone();
            $this.find(".img ul").append(clone);
            var size = $this.find(".img ul li").length; //获取img的数量

            //初始化.num
            var $num = $("<ul class='num'></ul>");
            $this.append($num);
            for (var j = 0; j < size - 1; j++) {
                if (options.numStyle) {
                    $this.find(".num").append("<li>" + (j + 1) + "</li>");
                } else {
                    $this.find(".num").append("<li></li>");
                }

            }
            $this.find(".num li").first().addClass("on");

            //初始化.btn			
            /*if(options.isBtn){				
            	$this.append("<div class='btn btn_l'>&lt;</div><div class='btn btn_r'>&gt;</div>");
            }	*/

            //鼠标划入圆点事件
            /*$this.find(".num li").hover(function(){
            	var index=$(this).index();
            	i=index;
            	$this.find(".img ul").stop().animate({left:-index*100%},options.nextImgSpeed);
            	$(this).addClass("on").siblings().removeClass("on");
            });*/

            //左按钮事件
            /*$this.find(".btn_l").click(moveR);*/
            //右按钮事件
            /*$this.find(".btn_r").click(moveL);	*/


            /*左滑事件*/
            $('.banner .img ul').swipeRight(function() {
                moveR();
            });

            $('.banner .img ul').swipeLeft(function() {
                moveL();
            });

            //自动轮播
            if(options.isAutoMove){
                
                    var t=setInterval(moveL,options.autoMoveTime);
                
                
            } 

            //手指接触屏幕事件
            $this.on('touchstart',function(){
                clearInterval(t);
               
            });
            $this.on('touchend',function(){
                t=setInterval(moveL,options.autoMoveTime);
                 
            });

            //向左移动函数
            function moveL() {
                i++;
                if (i == size) {
                    $this.find(".img ul").css({ left: 0 });
                    i = 1;
                }
                $this.find(".img ul").animate({ left: -i * 100+'%' }, options.nextImgSpeed);
                if (i == size - 1) {
                    $this.find(".num li").eq(0).addClass("on").siblings().removeClass("on");
                } else {
                    $this.find(".num li").eq(i).addClass("on").siblings().removeClass("on");
                }

            }

            //向右移动函数
            function moveR() {
                i--;
                if (i == -1) {
                    $this.find(".img ul").css({ left: -(size - 1) * 100+'%' });
                    i = size - 2;
                }
                $this.find(".img ul").animate({ left: -i * 100+'%' }, options.nextImgSpeed);
                $this.find(".num li").eq(i).addClass("on").siblings().removeClass("on");
            }

        });
    };

})(Zepto, window, document);

