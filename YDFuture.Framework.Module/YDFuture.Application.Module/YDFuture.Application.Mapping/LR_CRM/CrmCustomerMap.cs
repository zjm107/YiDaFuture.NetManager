using YiDaFuture.Application.CRM;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 �ڴ�δ���Ƽ���չ���޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-07-11 09:43
    /// �� �����ͻ�����
    /// </summary>
    public class CrmCustomerMap : EntityTypeConfiguration<CrmCustomerEntity>
    {
        public CrmCustomerMap()
        {
            #region ������
            //��
            this.ToTable("LR_CRM_CUSTOMER");
            //����
            this.HasKey(t => t.F_CustomerId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}

