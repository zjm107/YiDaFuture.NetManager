﻿/*
 * Ver 8.0(http://www.learun.cn)
 * Copyright (c) 2019 亿达未来科技发展有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.04.11
 * 描 述：区域管理	
 */
var acceptClick;
var bootstrap = function ($, learun) {
    "use strict";
    var currentData = top.layer_Form.currentData;

    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            // 数据来源设置
            $('#F_DataItemCode').lrselect({
                allowSearch: true,
                maxHeight: 130,
                url: top.$.rootUrl + '/LR_SystemModule/DataItem/GetClassifyTree',
                type: 'tree'
            });

            $('#F_DataSourceId').lrformselect({
                placeholder: '请选择数据源项',
                layerUrl: top.$.rootUrl + '/LR_SystemModule/DataSource/SelectForm',
                layerUrlH: 500,
                layerUrlW: 800,
                dataUrl: top.$.rootUrl + '/LR_SystemModule/DataSource/GetNameByCode'
            });

            $('#F_RelationType').lrselect({
                data: [{ "id": 0, "text": "无关联" }, { "id": 1, "text": "GUID" }, { "id": 2, "text": "数据字典" }, { "id": 3, "text": "数据来源" }, { "id": 4, "text": "固定数据" }, { "id": 5, "text": "登录者ID" }, { "id": 6, "text": "登录者名字" }, { "id": 7, "text": "导入时间" }],
                placeholder: false,
                maxHeight: 190,
                select: function (item) {
                    $('#F_DataItemCode').parent().hide();
                    $('#F_DataSourceId').parent().hide();
                    $('#F_Value').parent().hide();
                    if (item.id == 2) {
                        $('#F_DataItemCode').parent().show();
                    }
                    else if (item.id == 3) {
                        $('#F_DataSourceId').parent().show();
                    }
                    else if (item.id == 4) {
                        $('#F_Value').parent().show();
                    }
                }
            });
        },
        initData: function () {
            if (!!currentData) {
                $('#form').lrSetFormData(currentData);
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        var formData = $('#form').lrGetFormData();
        if (!!callBack) {
            callBack(formData);
        }
        return true;
    };
    page.init();
}