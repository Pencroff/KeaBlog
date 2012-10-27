/**
 * Created with JetBrains WebStorm.
 * User: Sergei Danilov
 * Date: 02.10.12
 * Time: 17:51
 */

/*global define:true, Backbone:true, SimpleShadow:true*/

define([
    'underscore',
    'backbone',
    'source/models/simple-shadow'
], function (_, Backbone, simpleModel) {
    'use strict';
    var SimpleShadowCollection = Backbone.Collection.extend({
        model: simpleModel
    });
    return SimpleShadowCollection;
});
