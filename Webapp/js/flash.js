//greenerycn@163.com
//插入不透明flash,透明flash
//elm为div的name，url为swf文件的路径，w为宽度，h为高度
function Insert_Flash(elm, url, w, h) {
if (!document.getElementById(elm)) return;
var str = '';
str += '<object width="'+ w +'" height="'+ h +'" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0">';
str += '<param name="movie" value="'+ url +'">';
str += '<param name="wmode" value="opaque">';//不透明
str += '<param name="quality" value="autohigh">';
str += '<embed width="'+ w +'" height="'+ h +'" src="'+ url +'" quality="autohigh" wmode="opaque" type="application/x-shockwave-flash" plugspace="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"></embed>';
str += '</object>';
document.getElementById(elm).innerHTML = str;
}
//插入透明flash
function Insert_Bg_Flash(elm,url,w,h)
{
if (!document.getElementById(elm)) return;
var str = '';
str += '<object type="application/x-shockwave-flash" data="'+url+'" width="'+ w +'" height="'+ h +'">';
str += '<param name="movie" value="'+ url +'">';
str += '<param name="wmode" value="transparent">';
str += '<param name="quality" value="autohigh">';
str += '</object>';
document.getElementById(elm).innerHTML = str;
}

