/**
 * Created with JetBrains WebStorm.
 * User: Sergei Danilov
 * Date: 02.10.12
 * Time: 16:36
 */

/*global define:true, Backbone:true, SimpleShadow:true, SimpleShadowCollection:true*/
define([
    'underscore',
    'backbone',
    'source/models/simple-shadow',
    'source/collections/simple-shadows',
    'source/common'
],  function (_, Backbone, SimpleShadow, SimpleShadowCollection, Common) {
    'use strict';
    var MainModel = Backbone.Model.extend({
        defaults: {
            text: "Sample text",
            color: 'ffd',
            background: 'aaa',
            fontSize: 64,
            fontName: 'Georgia',
            shadowStyle: 'text-shadow: 1px 1px 0px rgba(0, 0, 0, 1.0), 2px 2px 3px rgba(255, 255, 255, 1.0);',
            collection: null
        },
        initialize: function () {
            var collection = this.get('collection');
            this.on('add', this.refreshStyle, this);
            this.on('change', this.refreshStyle, this);
            this.on('remove', this.refreshStyle, this);
            collection.on('add', this.refreshStyle, this);
            collection.on('change', this.refreshStyle, this);
            collection.on('remove', this.refreshStyle, this);
        },
        refreshStyle: function () {
            var collection = this.get('collection'),
                template = _.template('<%= hShadow %>px <%= vShadow %>px <%= blur %>px <%= fullColor %>'),
                pref = 'text-shadow:',
                result = '';
            if (collection.length !== 0) {
                _.each(collection.models, function (element) {
                    var curColor = element.get('color');
                    if (Common.isColor(curColor)) {
                        if (result !== '') {
                            result += ',\r\n\t\t';
                        }
                        result += template(element.toJSON());
                    }
                });
                result = pref + result + ';';
            } else {
                result = '';
            }
            this.set('shadowStyle', result);
        }
    });
    return MainModel;
});