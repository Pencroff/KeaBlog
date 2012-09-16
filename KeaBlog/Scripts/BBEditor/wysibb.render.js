/**
 * Created with JetBrains WebStorm.
 * File: wysibb.render
 * User: daniloff
 * Date: 7/24/12 - 5:43 PM
 */

/*global $:true, hljs:true */
var wysibb = wysibb || {};

wysibb.render = function (bbdata) {
    "use strict";
    bbdata = bbdata.replace(/</g, "&lt;");

    $.each(wysibb.options.smileList, function (i, row) {
        bbdata = bbdata.replace(new RegExp(wysibb.helpers.prepareRGX(row.bbcode), "g"), wysibb.helpers.strf(row.img, wysibb.options));
    });

    $.each(wysibb.options.allButtons, function (i, b) {
        if (!!b.transform) {
            $.each(b.transform, function (html, bb) {
                var am, nhtml,
                    n = 0,
                    a = [],
                    r = {},
                    copyField = function (i, k) {
                        r[k] = am[i + 1];
                    };
                html = html.replace(/\n/g, ""); //IE 7,8 FIX
                bb = bb.replace(/(\(|\)|\[|\]|\.|\*|\?|\:|\\|\\)/g, "\\$1").replace(" ", "\\s+");
                bb = bb.replace(/\{\S+?\}/gi, function (s) {
                    s = s.substr(1, s.length - 2);
                    a.push(s);
                    return "([\\s\\S]*?)";
                });
                //var rgx = new RegExp(bb,"mgi");
                while ((am = (new RegExp(bb, "mgi")).exec(bbdata)) !== null) {
                    if (am) {
                        $.each(a, copyField);
                        nhtml = html;
                        nhtml = wysibb.helpers.strf(nhtml, r);
                        bbdata = bbdata.replace(am[0], nhtml);
                    }
                }
            });
        }
    });

    $.each(wysibb.options.systr, function (html, bb) {
        bb = bb.replace(/(\(|\)|\[|\]|\.|\*|\?|\:|\\|\\)/g, "\\$1").replace(" ", "\\s+");
        bbdata = bbdata.replace(new RegExp(bb, "g"), html);
    });
    if (typeof hljs !== 'undefined') {
        var text, result, endIndex, leftText, rightText,
            startIndex = 0;
        while (true) {
            startIndex = bbdata.indexOf('<pre', startIndex);
            if (startIndex === -1) {
                break;
            }
            endIndex = bbdata.indexOf('/pre>', startIndex);
            if (endIndex === -1) {
                break;
            } else {
                endIndex += 5;
            }
            text = bbdata.substring(startIndex, endIndex);
            var textObj = $(text)[0];
            if (!textObj.parentNode.className) {
                textObj.parentNode.className = "";
            }
            hljs.highlightBlock(textObj, null, true);
            result = textObj.outerHTML;
            leftText = bbdata.substring(0, startIndex);
            rightText = bbdata.substring(endIndex);
            bbdata = leftText + result + rightText;
            startIndex += result.length;
        }
    }
    return bbdata;
};

wysibb.helpers = {
    prepareRGX: function (r) {
        "use strict";
        //return r.replace(/(\[|\]|\)|\(|\.|\*|\?|\:|\|)/g, "\\$1").replace(/\{.*?\}/g, "([\\s\\S]*?)");
        return r.replace(/(\[|\]|\)|\(|\.|\*|\?|\:|\||\\)/g,"\\$1").replace(/\{.*?\}/g,"([\\s\\S]*?)");
    },
    strf: function (str, data) {
        "use strict";
        data = this.keysToLower($.extend({}, data));
        return str.replace(/\{([\w\.]*)\}/g, function (str, key) {
            key = key.toLowerCase();
            var keys = key.split("."),
                value = data[keys.shift().toLowerCase()];
            $.each(keys, function () {
                value = value[this];
            });
            return (value === null || value === undefined) ? "" : value;
        });
    },
    keysToLower: function (o) {
        "use strict";
        $.each(o, function (k, v) {
            if (k !== k.toLowerCase()) {
                delete o[k];
                o[k.toLowerCase()] = v;
            }
        });
        return o;
    }

};