
/*global define:true*/
define([], function () {
    'use strict';
	return {
        converter: {
            rgbToHex: function (r, g, b) {
                var decColor = (r << 16) + (g << 8) + b;
                return decColor.toString(16);
            },
            hexToRgb: function (hex) {
                var result = null;
                // Look for #a0b1c2
                result = /([a-fA-F0-9]{2})([a-fA-F0-9]{2})([a-fA-F0-9]{2})/.exec(hex);
                if (result) {
                    return {
                        r: parseInt(result[1], 16),
                        g: parseInt(result[2], 16),
                        b: parseInt(result[3], 16)
                    };
                }
                // Look for #fff
                result = /([a-fA-F0-9])([a-fA-F0-9])([a-fA-F0-9])/.exec(hex);
                if (result) {
                    return {
                        r: parseInt(result[1] + result[1], 16),
                        g: parseInt(result[2] + result[2], 16),
                        b: parseInt(result[3] + result[3], 16)
                    };
                }
                return result;
            }
        },
        isColor: function (colorHex) {
            var regColorCode = /^(#)?([0-9a-fA-F]{3})([0-9a-fA-F]{3})?$/;
            return regColorCode.test(colorHex);
        },
        // What is the enter key constant?
		ENTER_KEY: 13
	};
});
