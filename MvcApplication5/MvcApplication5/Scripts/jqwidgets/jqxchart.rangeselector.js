/*
jQWidgets v3.4.0 (2014-June-23)
Copyright (c) 2011-2014 jQWidgets.
License: http://jqwidgets.com/license/
*/

(function(a){a.extend(a.jqx._jqxChart.prototype,{_renderCategoryAxisRangeSelector:function(o,m){var p=this;p._isTouchDevice=a.jqx.mobile.isTouchDevice();var d=p._getCategoryAxis(o);var h=p.seriesGroups[o];if(!d||d.visible==false||h.type=="spider"){return}if(!p._isGroupVisible(o)){return}var k=d.rangeSelector;if(!k){return}if(!this._isSelectorRefresh){this.host.find(".rangeSelector").remove()}var f=h.orientation=="horizontal";if(k.renderTo){f=false}if(p.rtl){d.flip=true}var c=f?this.host.height():this.host.width();c-=3;var n=this._getCategoryAxisStats(o,d,c);var j=d.position;if(k.renderTo&&k.position){j=k.position}if(!this._isSelectorRefresh){var l=k.renderTo;var b="<div class='rangeSelector jqx-disableselect' style='position: absolute; background-color: transparent;' onselectstart='return false;'></div>";var e=a(b).appendTo(l?l:this.host.find(".chartContainer"));if(!l){var i=this.host.coord();selectorSize=this._selectorGetSize(d);if(!f){e.css("left",i.left+1);e.css("top",i.top+m.y+(j!="top"?m.height:-selectorSize));e.css("height",selectorSize);e.css("width",c);m.width=selectorSize}else{e.css("left",i.left+1+m.x+(j!="right"?-selectorSize:m.width));e.css("top",i.top);e.css("height",c);e.css("width",selectorSize);m.height=selectorSize}}else{e.css({width:l.width(),height:l.height()});m.width=l.width();m.height=l.height()}this._refreshSelector(o,d,n,e,m,f)}},_refreshSelector:function(f,e,d,z,c,b){var B={};var t=e.rangeSelector;var k=this.seriesGroups[f];for(var v in t){B[v]=t[v]}var q=B.minValue;var u=B.maxValue;if(undefined==q){q=Math.min(d.min.valueOf(),d.dsRange.min.valueOf())}if(undefined==u){u=Math.max(d.max.valueOf(),d.dsRange.max.valueOf())}if(this._isDate(d.min)){q=new Date(q)}if(this._isDate(d.max)){u=new Date(u)}var l=e.position;if(t.renderTo&&t.position){l=t.position}B.dataField=e.dataField;B.rangeSelector=undefined;B.type=e.type;B.baseUnit=t.baseUnit||e.baseUnit;B.minValue=q;B.maxValue=u;B.flip=e.flip;B.position=l;var h=5;var p=b?0:c.x;var y=b?0:this.padding.right;var x=b?c.y:h;var C=b?this._paddedRect.height-this._plotRect.height:h;var n=t.padding;if(n==undefined&&!t.renderTo){n={left:p,top:x,right:y,bottom:C}}else{n={left:((n&&n.left)?n.left:p),top:((n&&n.top)?n.top:x),right:((n&&n.right)?n.right:y),bottom:((n&&n.bottom)?n.bottom:C)}}var s=e.rangeSelector.dataField;for(var v=0;undefined==s&&v<this.seriesGroups.length;v++){for(var r=0;undefined==s&&r<this.seriesGroups[v].series.length;r++){s=this.seriesGroups[v].series[r].dataField}}var m={padding:n,title:t.title||"",description:t.description||"",titlePadding:t.titlePadding,colorScheme:t.colorScheme||this.colorScheme,backgroundColor:t.backgroundColor||this.backgroundColor||"transparent",backgroundImage:t.backgroundImage||"",showBorderLine:t.showBorderLine||(t.renderTo?true:false),borderLineWidth:t.borderLineWidth||this.borderLineWidth,borderLineColor:t.borderLineColor||this.borderLineColor,rtl:t.rtl||this.rtl,greyScale:t.greyScale||this.greyScale,showLegend:false,enableAnimations:false,enableEvents:false,showToolTips:false,source:this.source,xAxis:B,seriesGroups:[{orientation:b?"horizontal":"vertical",valueAxis:{visible:false},type:e.rangeSelector.serieType||"area",series:[{dataField:s,opacity:0.8,lineWidth:1}]}]};z.empty();z.jqxChart(m);var o=this;z.on(o._getEvent("mousemove"),function(){o._unselect();o._hideToolTip()});var w=z.jqxChart("getInstance");if(!w._plotRect){return}var A=w._paddedRect;A.height=w._plotRect.height;if(!b&&l=="top"){A.y+=w._renderData[0].xAxis.rect.height}else{if(b){var g=w._renderData[0].xAxis.rect.width;A.width-=g;if(l!="right"){A.x+=g}}}o._createSliderElements(f,z,A,t);o.addHandler(a(document),o._getEvent("mousemove"),o._onSliderMouseMove,{self:this,groupIndex:f,renderTo:z,swapXY:b});o.addHandler(a(document),o._getEvent("mousedown"),o._onSliderMouseDown,{self:this,groupIndex:f,renderTo:z,swapXY:b});o.addHandler(a(document),o._getEvent("mouseup"),o._onSliderMouseUp,{self:this,groupIndex:f,renderTo:z,swapXY:b})},_createSliderElements:function(q,k,l,m){k.find(".slider").remove();var p=m.colorSelectedRange||"blue";var g=m.colorUnselectedRange||"white";var b=a("<div class='slider' style='position: absolute;'></div>");b.css({background:p,opacity:0.1,left:l.x,top:l.y,width:l.width,height:l.height});b.appendTo(k);if(!this._sliders){this._sliders=[]}while(this._sliders.length<q+1){this._sliders.push({})}var i="<div class='slider' style='position: absolute;  background: "+g+"; opacity: 0.5;'></div>";var c="<div class='slider' style='position: absolute; background: grey; opacity: 0.5;'></div>";this._sliders[q]={element:b,host:k,fullRect:{x:b.coord().left,y:b.coord().top,width:l.width,height:l.height},rect:l,left:a(i),right:a(i),leftTop:a(c),rightTop:a(c),leftBorder:a(c),rightBorder:a(c)};this._sliders[q].left.appendTo(k);this._sliders[q].right.appendTo(k);this._sliders[q].leftTop.appendTo(k);this._sliders[q].rightTop.appendTo(k);this._sliders[q].leftBorder.appendTo(k);this._sliders[q].rightBorder.appendTo(k);var o=this._renderData[q].xAxis;var e=o.data.axisStats;var n=e.min.valueOf();var f=e.max.valueOf();var h=this._valueToOffset(q,n);var j=this._valueToOffset(q,f);if(h>j){var d=j;j=h;h=d}if(this.seriesGroups[q].orientation!="horizontal"){b.css({left:Math.round(l.x+h),top:l.y,width:Math.round(j-h),height:l.height})}else{b.css({top:Math.round(l.y+h),left:l.x,height:Math.round(j-h),width:l.width})}this._setSliderPositions(q,h,j)},_setSliderPositions:function(r,n,o){var l=this.seriesGroups[r];var e=this._getCategoryAxis(r);var h=e.rangeSelector;var k=l.orientation=="horizontal";if(e.rangeSelector.renderTo){k=false}var m=e.position;if(h.renderTo&&h.position){m=h.position}var q=(k&&m=="right")||(!k&&m=="top");var c=this._sliders[r];var d=k?"top":"left";var s=k?"left":"top";var i=k?"height":"width";var f=k?"width":"height";var j=k?"y":"x";var b=k?"x":"y";var p=c.rect;c.left.css(d,p[j]);c.left.css(s,p[b]);c.left.css(i,n);c.left.css(f,p[f]);c.right.css(d,p[j]+o);c.right.css(s,p[b]);c.right.css(i,p[i]-o+1);c.right.css(f,p[f]);c.leftTop.css(d,p[j]);c.leftTop.css(s,p[b]+(((k&&m=="right")||(!k&&m!="top"))?0:p[f]));c.leftTop.css(i,n);c.leftTop.css(f,1);c.rightTop.css(d,p[j]+o);c.rightTop.css(s,p[b]+(((k&&m=="right")||(!k&&m!="top"))?0:p[f]));c.rightTop.css(i,p[i]-o+1);c.rightTop.css(f,1);c.leftBorder.css(d,p[j]+n);c.leftBorder.css(s,p[b]);c.leftBorder.css(i,1);c.leftBorder.css(f,p[f]);c.rightBorder.css(d,p[j]+o);c.rightBorder.css(s,p[b]);c.rightBorder.css(i,1);c.rightBorder.css(f,p[f])},_resizeState:{},_onSliderMouseDown:function(d){var b=d.data.self;var c=b._sliders[d.data.groupIndex];if(!c){return}if(b._resizeState.state==undefined){b._testAndSetReadyResize(d)}if(b._resizeState.state!="ready"){return}b._resizeState.state="resizing"},_valueToOffset:function(m,k){var l=this.seriesGroups[m];var d=this._sliders[m];var c=d.host.jqxChart("getInstance");var n=c._renderData[0].xAxis;var g=n.data.axisStats;var j=Math.min(g.min.valueOf(),g.dsRange.min.valueOf());var b=Math.max(g.max.valueOf(),g.dsRange.max.valueOf());var h=b-j;if(h==0){h=1}var e=this._getCategoryAxis(m);var f=l.orientation=="horizontal"?"height":"width";var i=(k.valueOf()-j)/h;return d.fullRect[f]*(e.flip?(1-i):i)},_offsetToValue:function(o,f){var d=this._sliders[o];var n=this.seriesGroups[o];var e=this._getCategoryAxis(o);var g=n.orientation=="horizontal"?"height":"width";var i=d.fullRect[g];if(i==0){i=1}var j=f/i;var c=d.host.jqxChart("getInstance");var m=c._renderData[0].xAxis;var h=m.data.axisStats;var k=Math.min(h.min.valueOf(),h.dsRange.min.valueOf());var b=Math.max(h.max.valueOf(),h.dsRange.max.valueOf());var l=f/i*(b-k)+k;if(e.flip==true){l=b-f/i*(b-k)}if(this._isDate(h.min)||this._isDate(h.max)){l=new Date(l)}else{if(e.dataField==undefined){l=Math.round(l)}if(l<h.min){l=h.min}if(l>h.max){l=h.max}}return l},_onSliderMouseUp:function(o){var j=o.data.self;var f=o.data.groupIndex;var b=o.data.swapXY;var l=j._sliders[f];if(!l){return}if(j._resizeState.state!="resizing"){return}j._resizeState={};j.host.css("cursor","default");var g=!b?"left":"top";var c=!b?"width":"height";var n=!b?"x":"y";var m=l.element.coord()[g];var d=m+(!b?l.element.width():l.element.height());var h=j._offsetToValue(f,m-l.fullRect[n]);var p=j._offsetToValue(f,d-l.fullRect[n]);var i=l.host.jqxChart("getInstance");var k=i._renderData[0].xAxis;var r=k.data.axisStats;if(!r.isTimeUnit&&(p.valueOf()-h.valueOf())>86400000){h.setHours(0,0,0,0);p.setDate(p.getDate()+1);p.setHours(0,0,0,0)}var e=j._getCategoryAxis(f);if(e.flip){var q=h;h=p;p=q}e.minValue=h;e.maxValue=p;j._isSelectorRefresh=true;var s=j.enableAnimations;j.enableAnimations=false;j.update();j.enableAnimations=s},_onSliderMouseMove:function(t){var o=t.data.self;var v=t.data.renderTo;var i=t.data.groupIndex;var q=o._sliders[i];var d=t.data.swapXY;if(!q){return}var f=q.fullRect;var h=q.element;var w=a.jqx.position(t);var r=h.coord();var p=d?"left":"top";var m=!d?"left":"top";var g=d?"width":"height";var e=!d?"width":"height";var s=!d?"x":"y";if(o._resizeState.state=="resizing"){if(o._resizeState.side=="left"){var n=Math.round(w[m]-r[m]);var l=f[s];if(r[m]+n>=l&&r[m]+n<=l+f[e]){var j=parseInt(h.css(m));var c=Math.max(2,(d?h.height():h.width())-n);h.css(e,c);h.css(m,j+n)}}else{if(o._resizeState.side=="right"){var b=d?h.height():h.width();var n=Math.round(w[m]-r[m]-b);var l=f[s];if(r[m]+b+n>=l&&r[m]+n+b<=l+f[e]){var c=Math.max(2,b+n);h.css(e,c)}}}var u=parseInt(h.css(m))-q.rect[s];var k=u+(d?h.height():h.width());o._setSliderPositions(i,u,k)}else{o._testAndSetReadyResize(t)}},_testAndSetReadyResize:function(b){var q=b.data.self;var k=b.data.renderTo;var o=b.data.groupIndex;var c=q._sliders[o];var g=b.data.swapXY;var m=c.fullRect;var e=c.element;var f=a.jqx.position(b);var h=e.coord();var j=g?"left":"top";var p=!g?"left":"top";var i=g?"width":"height";var l=!g?"width":"height";var d=!g?"x":"y";var n=q._isTouchDevice?15:5;if(f[j]>=h[j]&&f[j]<=h[j]+m[i]){if(Math.abs(f[p]-h[p])<=n){k.css("cursor",g?"row-resize":"col-resize");q._resizeState={state:"ready",side:"left"}}else{if(Math.abs(f[p]-h[p]-(!g?e.width():e.height()))<=n){k.css("cursor",g?"row-resize":"col-resize");q._resizeState={state:"ready",side:"right"}}else{k.css("cursor","default");q._resizeState={}}}}else{k.css("cursor","default");q._resizeState={}}},_selectorGetSize:function(b){if(b.rangeSelector.renderTo){return 0}return b.rangeSelector.size||this._paddedRect.height/3}})})(jQuery);