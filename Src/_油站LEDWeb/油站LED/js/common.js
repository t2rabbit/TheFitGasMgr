var vUrl = "https://www.lmx.ren/kankan";
//var vUrl = "http://localhost:5125";
//var vUrl="http://192.168.31.175:807";
//var vUrl = "http://192.168.2.241:829";

var SystemTitle = 'Oil station LED management system';
var isWeChat = true;
var VIntervelTime = 6000; //定时refresh时间,组织:毫秒
var VPageIndex = 1; //页面
var VPageSize = 20; //页面List个数
// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
//Date.prototype.Format = function(fmt) { //author: meizz 
//	var o = {
//	    "M+": fmt.getMonth() + 1, //月份 
//	    "d+": fmt.getDate(), //日 
//	    "h+": fmt.getHours(), //小时 
//	    "m+": fmt.getMinutes(), //分 
//	    "s+": fmt.getSeconds(), //秒 
//	    "q+": Math.floor((fmt.getMonth() + 3) / 3), //季度 
//	    "S": fmt.getMilliseconds() //毫秒 
//	};
//	if(/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
//	for(var k in o)
//		if(new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
//	return fmt;
//};

// GetUrl的参数
function getQueryString(name) {
	if(fBrowserIsWeChat()) {
		var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
		var r = window.location.search.substr(1).match(reg);
		if(r != null) return unescape(r[2]);
		return null;
	} else {
		var vValue = null;
		var wv = plus.webview.currentWebview();
		if(name == "objectid") {
			vValue = wv.objectid;
		} else if(name == 'lng') {
			vValue = wv.lng;
		} else if(name == 'lat') {
			vValue = wv.lat;
		} else if(name == 'direct') {
			vValue = wv.direct;
		} else if(name == 'carimg') {
			vValue = wv.carimg;
		} else if(name == 'carName') {
			vValue = wv.carName;
		}
		return vValue;
	}
};
// Get参数方法
function getChineseQueryString(name) {
	if(fBrowserIsWeChat()) {
		var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
		var r = window.location.search.substr(1).match(reg);
		if(r != null) {
			return encodeURI(r[2]); //中文的话，就用encodeURI，如果是英文，则用：unescape即可
		} else {
			return null;
		}
	} else {
		var vValue = null;
		var wv = plus.webview.currentWebview();
		if(name == "objectid") {
			vValue = wv.objectid;
		} else if(name == 'lng') {
			vValue = wv.lng;
		} else if(name == 'lat') {
			vValue = wv.lat;
		} else if(name == 'direct') {
			vValue = wv.direct;
		} else if(name == 'carimg') {
			vValue = wv.carimg;
		} else if(name == 'carName') {
			vValue = wv.carName;
		}
		return vValue;
	}
}
//检查值是否为空
function fCheckIsNull(value) {
	var vResult = false;
	if(value == null) {
		vResult = true;
	}
	if(value == "null") {
		vResult = true;
	}
	if(value == undefined) {
		vResult = true;
	}
	if(value == "undefined") {
		vResult = true;
	}
	if(value == "") {
		vResult = true;
	}
	if(value == '') {
		vResult = true;
	}
	return vResult;
};
// Get浏览器Information
function fGetAgentInfo() {
	var agent = navigator.userAgent.toLowerCase();
	return agent;
};
//判断当前浏览器是否为微信内置浏览器
function fBrowserIsWeChat() {
	bResult = false;
	var ua = navigator.userAgent.toLowerCase();
	if(ua.match(/MicroMessenger/i) == "micromessenger") { //微信内置浏览器
		bResult = true;
	}
	if(ua.match(/mobile/i) == "mobile") { //电脑浏览器模仿的手机模式浏览器
		bResult = true;
	}
	if(ua.match(/html5plus/i) == "html5plus") { //MUI的APP内置浏览器
		bResult = false;
	}
	return bResult;
};
//以标签的name来 GetRadio的Check的值
function fGetRadioBoxValue(radioName) {
	var obj = document.getElementsByName(radioName); //这个是以标签的name来取控件
	for(i = 0; i < obj.length; i++) {
		if(obj[i].checked) {
			return obj[i].value;
		}
	}
};
//Close除了入口页以及当前页以外的其他WebView
function fCloseOtherWebView() {
	if(fBrowserIsWeChat() == false) {
		//当前窗口
		var ws = plus.webview.currentWebview();
		//启动页,保留,因为推送用到
		var h = plus.webview.getLaunchWebview();
		var wvs = plus.webview.all();
		for(var i = 0; i < wvs.length; i++) {
			if(wvs[i] != ws && wvs[i] != h) {
				plus.webview.close(wvs[i]);
			}
		}
	}
}

//哈希表
function HashTable() {
	var size = 0;
	var entry = new Object();
	this.add = function(key, value) {
		if(!this.containsKey(key)) {
			size++;
		}
		entry[key] = value;
	}
	this.getValue = function(key) {
		return this.containsKey(key) ? entry[key] : null;
	}
	this.remove = function(key) {
		if(this.containsKey(key) && (delete entry[key])) {
			size--;
		}
	}
	this.containsKey = function(key) {
		return(key in entry);
	}
	this.containsValue = function(value) {
		for(var prop in entry) {
			if(entry[prop] == value) {
				return true;
			}
		}
		return false;
	}
	this.getValues = function() {
		var values = new Array();
		for(var prop in entry) {
			values.push(entry[prop]);
		}
		return values;
	}
	this.getKeys = function() {
		var keys = new Array();
		for(var prop in entry) {
			keys.push(prop);
		}
		return keys;
	}
	this.getSize = function() {
		return size;
	}
	this.clear = function() {
		size = 0;
		entry = new Object();
	}
}
//签名
function GetSign(param) {
	var array = new Array();
	for(var key in param) {
		array.push(key)
	}
	array.sort();
	var paramArray = new Array();
	for(var index in array) {
		var key = array[index];
		paramArray.push(key + param[key])
	}
	var shaSource = paramArray.join("");
	var sign = new String(hex_sha1(shaSource)).toUpperCase();
	var queryArray = new Array();
	queryArray.push("_sign=" + sign);
	for(var key in param) {
		queryArray.push(key + "=" + param[key])
	}
	var queryString = queryArray.join("&");
	return queryString
}
//打印Information输出
function WriteLog(type, msg) {
	console.log("type：" + type + "；msg：" + msg + "；time：" + new Date());
}
//随机数
function GetRandomNum(Min, Max) {
	var Range = Max - Min;
	var Rand = Math.random();
	return(Min + Math.round(Rand * Range));
}

function fCheckLogin() {
	var vUserInfo = plus.storage.getItem('UserInfo');
	if(fCheckIsNull(vUserInfo)) {
		mui.alert('请先登录', title, function() {
			mui.openWindow({
				id: 'login',
				url: 'login.html',
				show: {
					aniShow: 'pop-in'
				},
				styles: {
					popGesture: 'close'
				},
				extras: {
					entrance: "main"
				},
				waiting: {
					autoShow: true //自动显示等待框，默认为true
				}
			});
		})
		return;
	} else {
		vUserInfo = JSON.parse(vUserInfo);
	}
	return vUserInfo;
};

//随机数
function fGetRandomNum(Min, Max) {
	var Range = Max - Min;
	var Rand = Math.random();
	return(Min + Math.round(Rand * Range));
};