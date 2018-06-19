
function FloatMenu(){
	var animationSpeed=1500;
	var animationEasing='easeOutQuint';
	var scrollAmount=$(document).scrollTop();
	var newPosition=menuPosition+scrollAmount;
	if($(window).height()<$('#fl_menu').height()+$('#fl_menu .menu').height()){
		$('#fl_menu').css('top',menuPosition);
	} else {
		$('#fl_menu').stop().animate({top: newPosition}, animationSpeed, animationEasing);
	}
}
$(window).load(function(){
	menuPosition=$('#fl_menu').position().top;
	FloatMenu();
});
$(window).scroll(function(){ 
	FloatMenu();
});
$(document).ready(function(){
	var fadeSpeed=500;
	$("#fl_menu").hover(function(){
		$('#fl_menu .label').fadeTo(fadeSpeed, 1);
		$("#fl_menu .menu").fadeIn(fadeSpeed);
	},function(){
		$('#fl_menu .label').fadeTo(fadeSpeed, 0.75);
		$("#fl_menu .menu").fadeOut(fadeSpeed);
	});
});