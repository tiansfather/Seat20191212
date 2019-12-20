'use strict';(function(d){"object"==typeof exports&&"object"==typeof module?d(require("../../lib/codemirror")):"function"==typeof define&&define.amd?define(["../../lib/codemirror"],d):d(CodeMirror)})(function(d){d.defineMode("smarty",function(t,l){function e(a,b){m=b;return a}function h(a,b){for(var c=a.string,e=a.pos;;){var d=c.indexOf(g,e);e=d+g.length;var f;(f=-1==d)||(f=d+g.length,null==f&&(f=a.pos),f=!(3===p&&"{"==g&&(f==a.string.length||/\s/.test(a.string.charAt(f)))));if(f)break}if(d==a.pos){a.match(g);
if(a.eat("*"))return c=u("comment","*"+n),b.tokenize=c,c(a,b);b.depth++;b.tokenize=q;m="startTag";return"tag"}-1<d&&(a.string=c.slice(0,d));b=k.token(a,b.base);-1<d&&(a.string=c);return b}function q(a,b){if(a.match(n,!0))return 3===p?(b.depth--,0>=b.depth&&(b.tokenize=h)):b.tokenize=h,e("tag",null);if(a.match(g,!0))return b.depth++,e("tag","startTag");var c=a.next();if("$"==c)return a.eatWhile(f.validIdentifier),e("variable-2","variable");if("|"==c)return e("operator","pipe");if("."==c)return e("operator",
"property");if(f.stringChar.test(c))return b.tokenize=v(c),e("string","string");if(f.operatorChars.test(c))return a.eatWhile(f.operatorChars),e("operator","operator");if("["==c||"]"==c)return e("bracket","bracket");if("("==c||")"==c)return e("bracket","operator");if(/\d/.test(c))return a.eatWhile(/\d/),e("number","number");if("variable"==b.last){if("@"==c)return a.eatWhile(f.validIdentifier),e("property","property");if("|"==c)return a.eatWhile(f.validIdentifier),e("qualifier","modifier")}else{if("pipe"==
b.last)return a.eatWhile(f.validIdentifier),e("qualifier","modifier");if("whitespace"==b.last)return a.eatWhile(f.validIdentifier),e("attribute","modifier")}if("property"==b.last)return a.eatWhile(f.validIdentifier),e("property",null);if(/\s/.test(c))return m="whitespace",null;b="";"/"!=c&&(b+=c);for(var d;d=a.eat(f.validIdentifier);)b+=d;a=0;for(d=r.length;a<d;a++)if(r[a]==b)return e("keyword","keyword");return/\s/.test(c)?null:e("tag","tag")}function v(a){return function(b,c){for(var d=null,e;!b.eol();){e=
b.peek();if(b.next()==a&&"\\"!==d){c.tokenize=q;break}d=e}return"string"}}function u(a,b){return function(c,d){for(;!c.eol();){if(c.match(b)){d.tokenize=h;break}c.next()}return a}}var n=l.rightDelimiter||"}",g=l.leftDelimiter||"{",p=l.version||2,k=d.getMode(t,l.baseMode||"null"),r=["debug","extends","function","include","literal"],f={operatorChars:/[+\-*&%=<>!?]/,validIdentifier:/[a-zA-Z0-9_]/,stringChar:/['"]/},m;return{startState:function(){return{base:d.startState(k),tokenize:h,last:null,depth:0}},
copyState:function(a){return{base:d.copyState(k,a.base),tokenize:a.tokenize,last:a.last,depth:a.depth}},innerMode:function(a){if(a.tokenize==h)return{mode:k,state:a.base}},token:function(a,b){a=b.tokenize(a,b);b.last=m;return a},indent:function(a,b){return a.tokenize==h&&k.indent?k.indent(a.base,b):d.Pass},blockCommentStart:g+"*",blockCommentEnd:"*"+n}});d.defineMIME("text/x-smarty","smarty")});