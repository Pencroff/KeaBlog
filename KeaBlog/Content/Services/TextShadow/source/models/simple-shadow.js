/**
 * Created with JetBrains WebStorm.
 * User: Sergei Danilov
 * Date: 02.10.12
 * Time: 15:59
 */

/*global define:true, Backbone:true,*/
define([
    'underscore',
    'backbone',
    'source/common'
], function (_, Backbone, Common) {
    'use strict';
    var SimpleShadow = Backbone.Model.extend({
        defaults: {
            hShadow: 0,
            vShadow: 0,
            blur: 0,
            color: '000',
            fullColor: '',
            opacity: '1.0'
        },
        initialize: function () {
            this.on('change', this.refreshFullColor, this);
            this.refreshFullColor();
        },
        refreshFullColor: function () {
            var template = _.template('rgba(<%= color.r %>, <%= color.g %>, <%= color.b %>, <%= opacity %>)'),
                obj = {
                    color: Common.converter.hexToRgb(this.get('color')),
                    opacity: this.get('opacity')
                };
            this.set('fullColor', template(obj));
        }
    });
    return SimpleShadow;
});