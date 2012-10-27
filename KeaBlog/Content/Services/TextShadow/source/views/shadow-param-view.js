/**
 * Created with JetBrains WebStorm.
 * User: Sergei Danilov
 * Date: 09.10.12
 * Time: 17:51
 * File: shadow-param-view
 */

/*global define:true*/
define([
    'jquery',
    'underscore',
    'backbone',
    'source/models/simple-shadow',
    'text!source/templates/shadow-param-template.html'
], function ($, _, Backbone, SimpleShadow, shadowParamTemplate) {
    'use strict';
    var ShadowParamView = Backbone.View.extend({
        tagName:  'tr',
        template: _.template(shadowParamTemplate),
        initialize: function () {
            this.model.on('add-row', this.addRow, this);
            this.model.on('destroy', this.remove, this);
        },
        events: {
            'change .edit-row':	'updateModel',
            'click .delete-row': 'deleteRow'
        },
        render: function () {
            var result;
            if (this.model === null) {
                return;
            }
            result = this.template(this.model.toJSON());
            this.$el.html(result);
        },
        updateModel: function (e) {
            var htmlElement = e.currentTarget,
                attr = htmlElement.getAttribute("data-field");
            this.model.set(attr, htmlElement.value);
        },
        deleteRow: function (e) {
            this.model.destroy();
        }
    });
    return ShadowParamView;
});