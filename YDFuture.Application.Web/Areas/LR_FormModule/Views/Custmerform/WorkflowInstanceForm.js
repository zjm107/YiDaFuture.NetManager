﻿/*
 * Ver 8.0(http://www.learun.cn)
 * Copyright (c) 2019 亿达未来科技发展有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.04.17
 * 描 述：自定义表单-用于工作流
 */
var id = request('id');
var keyValue = "";

var processIdName = "";
var isUpdate = false;

// 保存数据
var save;
// 设置权限
var setAuthorize;
// 设置表单数据
var setFormData;
// 验证数据是否填写完整
var validForm;

var bootstrap = function ($, learun) {
    "use strict";
    var formModule;
    var girdCompontMap;

    var page = {
        init: function () {
            if (!!id) {
                $.lrSetForm(top.$.rootUrl + '/LR_FormModule/Custmerform/GetFormData?keyValue=' + id, function (data) {//
                    formModule = JSON.parse(data.schemeEntity.F_Scheme);
                    girdCompontMap = $.lrCustmerFormRender(formModule.data);
                });
            }
        },
        setFormData: function (data) {
            if (!!formModule) {
                $.each(data, function (id, item) {
                    if (!!girdCompontMap[id]) {
                        var fieldMap = {};
                        $.each(girdCompontMap[id].fieldsData, function (id, girdFiled) {
                            if (!!girdFiled.field) {
                                fieldMap[girdFiled.field.toLowerCase()] = girdFiled.field;
                            }
                        });
                        var rowDatas = [];
                        for (var i = 0, l = item.length; i < l; i++) {
                            var _point = {};
                            for (var _field in item[i]) {
                                _point[fieldMap[_field]] = item[i][_field];
                            }
                            rowDatas.push(_point);
                        }
                        if (rowDatas.length > 0) {
                            isUpdate = true;
                        }
                        $('#' + girdCompontMap[id].id).jfGridSet('refreshdata', { rowdatas: rowDatas });
                    }
                    else {
                        if (!!item[0]) {
                            isUpdate = true;
                            $('body').lrSetCustmerformData(item[0]);
                        }
                    }
                    
                });
            }
            else {
                setTimeout(function () {
                    page.setFormData(data);
                }, 100);
            }
        }
    };
    page.init();

    // 保存调用函数
    save = function (processId, callBack, i) {
        if (isUpdate) {
            keyValue = processId;
        }
        var formData = $('body').lrGetCustmerformData(keyValue);
        if (!!processIdName) {
            formData[processIdName] = processId;
        }
        var postData =
            {
                formData: JSON.stringify(formData)
            };
        $.lrSaveForm(top.$.rootUrl + '/LR_FormModule/Custmerform/SaveInstanceForm?keyValue=' + keyValue + "&schemeInfoId=" + id + '&processIdName=' + processIdName, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack(res, formData, i);
            }
        });
    };
    // 设置权限
    setAuthorize = function (data) {
        if (!!formModule) {
            for (var i = 0, l = data.length; i < l; i++) {
                var field = data[i];
                if (field.isLook != 1) {// 如果没有查看权限就直接移除
                    $('#' + field.fieldId).parent().remove();
                }
                else {
                    if (field.isEdit != 1) {
                        $('#' + field.fieldId).attr('disabled', 'disabled');
                        if ($('#' + field.fieldId).hasClass('lrUploader-wrap')) {
                            $('#' + field.fieldId).css({ 'padding-right': '58px' });
                            $('#' + field.fieldId).find('.btn-success').remove();
                        }
                    }
                }
            }
        }
        else {
            setTimeout(function () {
                setAuthorize(data);
            }, 100);
        }
    };

    // 设置表单数据
    setFormData = function (processId) {
        if (!!processId) {
            $.lrSetForm(top.$.rootUrl + '/LR_FormModule/Custmerform/GetInstanceForm?schemeInfoId=' + id + '&keyValue=' + processId + '&processIdName=' + processIdName, function (data) {//
                page.setFormData(data);
            });
        }
    };

    // 验证数据是否填写完整
    validForm = function () {
        if (!$.lrValidCustmerform()) {
            return false;
        }
        return true;
    };
}