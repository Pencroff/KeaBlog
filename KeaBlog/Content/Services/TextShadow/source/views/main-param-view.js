/**
 * Created with JetBrains WebStorm.
 * User: Sergei Danilov
 * Date: 09.10.12
 * Time: 12:40
 * File: main-param-view
 */

/*global define:true*/
define([
    'jquery',
    'underscore',
    'backbone',
    'text!source/templates/main-param-template.html'
], function ($, _, Backbone, mainParamTemplate) {
    'use strict';
    var MainParamView = Backbone.View.extend({
        template: _.template(mainParamTemplate),
        events: {
            'change .edit':	'updateModel'
        },
        initialize: function () {},
        render: function () {
            if (this.model === null) {
                return;
            }
            this.$el.html(this.template(this.model.toJSON()));
        },
        updateModel: function () {
            _.each($('.edit'), function (element) {
                var attr = element.getAttribute("data-field");
                this.model.set(attr, element.value);
            }, this);
            this.model.trigger('change-simple-model');
        }
    });
    return MainParamView;
});
