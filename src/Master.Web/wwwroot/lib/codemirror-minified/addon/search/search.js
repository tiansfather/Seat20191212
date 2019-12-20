'use strict';var $jscomp=$jscomp||{};$jscomp.scope={};$jscomp.findInternal=function(b,k,f){b instanceof String&&(b=String(b));for(var g=b.length,h=0;h<g;h++){var l=b[h];if(k.call(f,l,h,b))return{i:h,v:l}}return{i:-1,v:void 0}};$jscomp.ASSUME_ES5=!1;$jscomp.ASSUME_NO_NATIVE_MAP=!1;$jscomp.ASSUME_NO_NATIVE_SET=!1;$jscomp.defineProperty=$jscomp.ASSUME_ES5||"function"==typeof Object.defineProperties?Object.defineProperty:function(b,k,f){b!=Array.prototype&&b!=Object.prototype&&(b[k]=f.value)};
$jscomp.getGlobal=function(b){return"undefined"!=typeof window&&window===b?b:"undefined"!=typeof global&&null!=global?global:b};$jscomp.global=$jscomp.getGlobal(this);$jscomp.polyfill=function(b,k,f,g){if(k){f=$jscomp.global;b=b.split(".");for(g=0;g<b.length-1;g++){var h=b[g];h in f||(f[h]={});f=f[h]}b=b[b.length-1];g=f[b];k=k(g);k!=g&&null!=k&&$jscomp.defineProperty(f,b,{configurable:!0,writable:!0,value:k})}};
$jscomp.polyfill("Array.prototype.find",function(b){return b?b:function(b,f){return $jscomp.findInternal(this,b,f).v}},"es6","es3");
(function(b){"object"==typeof exports&&"object"==typeof module?b(require("../../lib/codemirror"),require("./searchcursor"),require("../dialog/dialog")):"function"==typeof define&&define.amd?define(["../../lib/codemirror","./searchcursor","../dialog/dialog"],b):b(CodeMirror)})(function(b){function k(a,c){"string"==typeof a?a=new RegExp(a.replace(/[\-\[\]\/\{\}\(\)\*\+\?\.\\\^\$\|]/g,"\\$&"),c?"gi":"g"):a.global||(a=new RegExp(a.source,a.ignoreCase?"gi":"g"));return{token:function(c){a.lastIndex=c.pos;
var b=a.exec(c.string);if(b&&b.index==c.pos)return c.pos+=b[0].length||1,"searching";b?c.pos=b.index:c.skipToEnd()}}}function f(){this.overlay=this.posFrom=this.posTo=this.lastQuery=this.query=null}function g(a){return a.state.search||(a.state.search=new f)}function h(a){return"string"==typeof a&&a==a.toLowerCase()}function l(a,c,b){return a.getSearchCursor(c,b,{caseFold:h(c),multiline:!0})}function z(a,c,b,d,e){a.openDialog(c,d,{value:b,selectValueOnOpen:!0,closeOnEnter:!1,onClose:function(){p(a)},
onKeyDown:e})}function t(a,c,b,d,e){a.openDialog?a.openDialog(c,e,{value:d,selectValueOnOpen:!0}):e(prompt(b,d))}function A(a,c,b,d){if(a.openConfirm)a.openConfirm(c,d);else if(confirm(b))d[0]()}function v(a){return a.replace(/\\(.)/g,function(a,b){return"n"==b?"\n":"r"==b?"\r":b})}function w(a){var b=a.match(/^\/(.*)\/([a-z]*)$/);if(b)try{a=new RegExp(b[1],-1==b[2].indexOf("i")?"":"i")}catch(B){}else a=v(a);if("string"==typeof a?""==a:a.test(""))a=/x^/;return a}function q(a,b,f){b.queryText=f;b.query=
w(f);a.removeOverlay(b.overlay,h(b.query));b.overlay=k(b.query,h(b.query));a.addOverlay(b.overlay);a.showMatchesOnScrollbar&&(b.annotate&&(b.annotate.clear(),b.annotate=null),b.annotate=a.showMatchesOnScrollbar(b.query,h(b.query)))}function n(a,c,f,d){var e=g(a);if(e.query)return r(a,c);var m=a.getSelection()||e.lastQuery;m instanceof RegExp&&"x^"==m.source&&(m=null);if(f&&a.openDialog){var u=null,h=function(c,d){b.e_stop(d);c&&(c!=e.queryText&&(q(a,e,c),e.posFrom=e.posTo=a.getCursor()),u&&(u.style.opacity=
1),r(a,d.shiftKey,function(b,c){var e;3>c.line&&document.querySelector&&(e=a.display.wrapper.querySelector(".CodeMirror-dialog"))&&e.getBoundingClientRect().bottom-4>a.cursorCoords(c,"window").top&&((u=e).style.opacity=.4)}))};z(a,'<span class="CodeMirror-search-label">Search:</span> <input type="text" style="width: 10em" class="CodeMirror-search-field"/> <span style="color: #888" class="CodeMirror-search-hint">(Use /re/ syntax for regexp search)</span>',m,h,function(c,e){var d=b.keyName(c),f=a.getOption("extraKeys");
d=f&&f[d]||b.keyMap[a.getOption("keyMap")][d];if("findNext"==d||"findPrev"==d||"findPersistentNext"==d||"findPersistentPrev"==d)b.e_stop(c),q(a,g(a),e),a.execCommand(d);else if("find"==d||"findPersistent"==d)b.e_stop(c),h(e,c)});d&&m&&(q(a,e,m),r(a,c))}else t(a,'<span class="CodeMirror-search-label">Search:</span> <input type="text" style="width: 10em" class="CodeMirror-search-field"/> <span style="color: #888" class="CodeMirror-search-hint">(Use /re/ syntax for regexp search)</span>',"Search for:",
m,function(b){b&&!e.query&&a.operation(function(){q(a,e,b);e.posFrom=e.posTo=a.getCursor();r(a,c)})})}function r(a,c,f){a.operation(function(){var d=g(a),e=l(a,d.query,c?d.posFrom:d.posTo);if(!e.find(c)&&(e=l(a,d.query,c?b.Pos(a.lastLine()):b.Pos(a.firstLine(),0)),!e.find(c)))return;a.setSelection(e.from(),e.to());a.scrollIntoView({from:e.from(),to:e.to()},20);d.posFrom=e.from();d.posTo=e.to();f&&f(e.from(),e.to())})}function p(a){a.operation(function(){var b=g(a);if(b.lastQuery=b.query)b.query=b.queryText=
null,a.removeOverlay(b.overlay),b.annotate&&(b.annotate.clear(),b.annotate=null)})}function x(a,b,f){a.operation(function(){for(var c=l(a,b);c.findNext();)if("string"!=typeof b){var e=a.getRange(c.from(),c.to()).match(b);c.replace(f.replace(/\$(\d)/g,function(a,b){return e[b]}))}else c.replace(f)})}function y(a,b){if(!a.getOption("readOnly")){var c=a.getSelection()||g(a).lastQuery,d='<span class="CodeMirror-search-label">'+(b?"Replace all:":"Replace:")+"</span>";t(a,d+' <input type="text" style="width: 10em" class="CodeMirror-search-field"/> <span style="color: #888" class="CodeMirror-search-hint">(Use /re/ syntax for regexp search)</span>',
d,c,function(c){c&&(c=w(c),t(a,'<span class="CodeMirror-search-label">With:</span> <input type="text" style="width: 10em" class="CodeMirror-search-field"/>',"Replace with:","",function(e){e=v(e);if(b)x(a,c,e);else{p(a);var d=l(a,c,a.getCursor("from")),f=function(){var b=d.from(),g;if(!(g=d.findNext())&&(d=l(a,c),!(g=d.findNext())||b&&d.from().line==b.line&&d.from().ch==b.ch))return;a.setSelection(d.from(),d.to());a.scrollIntoView({from:d.from(),to:d.to()});A(a,'<span class="CodeMirror-search-label">Replace?</span> <button>Yes</button> <button>No</button> <button>All</button> <button>Stop</button>',
"Replace?",[function(){h(g)},f,function(){x(a,c,e)}])},h=function(a){d.replace("string"==typeof c?e:e.replace(/\$(\d)/g,function(b,c){return a[c]}));f()};f()}}))})}}b.commands.find=function(a){p(a);n(a)};b.commands.findPersistent=function(a){p(a);n(a,!1,!0)};b.commands.findPersistentNext=function(a){n(a,!1,!0,!0)};b.commands.findPersistentPrev=function(a){n(a,!0,!0,!0)};b.commands.findNext=n;b.commands.findPrev=function(a){n(a,!0)};b.commands.clearSearch=p;b.commands.replace=y;b.commands.replaceAll=
function(a){y(a,!0)}});