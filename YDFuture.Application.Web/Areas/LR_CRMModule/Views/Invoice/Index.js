﻿/*
 * Ver 8.0(http://www.learun.cn)
 * Copyright (c) 2019 亿达未来科技发展有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.11.12
 * 描 述：客户开票信息管理	
 */
var refreshGirdData; // 更新数据
var selectedRow;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                selectedRow = null;//新增前请清空已选中行
                learun.layerForm({
                    id: 'form',
                    title: '新增客户',
                    url: top.$.rootUrl + '/LR_CRMModule/Invoice/Form',
                    width: 500,
                    height: 400,
                    maxmin: true,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                selectedRow = $('#girdtable').jfGridGet('rowdata');
                var keyValue = $('#girdtable').jfGridValue('F_InvoiceId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑客户',
                        url: top.$.rootUrl + '/LR_CRMModule/Invoice/Form',
                        width: 500,
                        height: 400,
                        maxmin: true,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_InvoiceId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CRMModule/Invoice/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#girdtable').jfGrid({
                url: top.$.rootUrl + '/LR_CRMModule/Invoice/GetPageListJson',
                headData: [
                    { label: '客户名称', name: 'F_CustomerName', width: 200, align: 'left' },
                    { label: '开票信息', name: 'F_InvoiceContent', width: 500, align: 'left' }
                ],
                mainId: 'F_InvoiceId',
                reloadSelected: true,
                isPage: true,
                sidx: 'F_CreateDate'
            });
            page.search();
        },
        search: function (param) {
            $('#girdtable').jfGridSet('reload', { param: param });
        }
    };
    // 保存数据后回调刷新
    refreshGirdData = function () {
        page.search();
    }
    page.init();
}


