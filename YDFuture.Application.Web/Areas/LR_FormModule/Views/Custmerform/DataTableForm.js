﻿/*
 * Ver 8.0(http://www.learun.cn)
 * Copyright (c) 2019 亿达未来科技发展有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.04.11
 * 描 述：表单设计数据表添加	
 */
var dbId = request('dbId');

var selectedRow = top.layer_Form.selectedRow;
var dbTable = top.layer_Form.dbTable;


var acceptClick;
var bootstrap = function ($, learun) {
    "use strict";

    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#field').lrselect({
                value: 'f_column',
                text: 'f_column',
                title: 'f_remark',
                allowSearch: true
            });
            $('#relationField').lrselect({
                value: 'f_column',
                text: 'f_column',
                title: 'f_remark',
                maxHeight: 130,
                allowSearch: true
            });
            $('#name').lrselect({
                url: top.$.rootUrl + '/LR_SystemModule/DatabaseTable/GetList',
                param: { databaseLinkId: dbId },
                value: 'name',
                text: 'name',
                title: 'tdescription',
                maxHeight: 200,
                allowSearch: true,
                select: function (item) {
                    $('#field').lrselectRefresh({
                        url: top.$.rootUrl + '/LR_SystemModule/DatabaseTable/GetFieldList',
                        param: { databaseLinkId: dbId, tableName: item.name }
                    });
                }
            });
            $('#relationName').lrselect({
                data: dbTable,
                param: { databaseLinkId: dbId },
                value: 'name',
                text: 'name',
                maxHeight: 160,
                allowSearch: true,
                select: function (item) {
                    $('#relationField').lrselectRefresh({
                        url: top.$.rootUrl + '/LR_SystemModule/DatabaseTable/GetFieldList',
                        param: { databaseLinkId: dbId, tableName: item.name }
                    });
                }
            });
        },
        initData: function () {
            if (!!selectedRow) {
                $('#form').lrSetFormData(selectedRow);
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }

        var data = $('#form').lrGetFormData();
        if (data.name == data.relationName)
        {
            learun.alert.error('关联表不能是自己本身！');
            return false;
        }
        if (!!callBack) {
            callBack(data);
        }
        return true;
    };
    page.init();
}