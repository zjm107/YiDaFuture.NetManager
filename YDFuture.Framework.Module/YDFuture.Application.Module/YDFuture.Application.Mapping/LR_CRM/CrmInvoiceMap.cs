using YiDaFuture.Application.CRM;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 �ڴ�δ���Ƽ���չ���޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-07-11 14:47
    /// �� ������Ʊ��Ϣ
    /// </summary>
    public class CrmInvoiceMap : EntityTypeConfiguration<CrmInvoiceEntity>
    {
        public CrmInvoiceMap()
        {
            #region ������
            //��
            this.ToTable("LR_CRM_INVOICE");
            //����
            this.HasKey(t => t.F_InvoiceId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}

