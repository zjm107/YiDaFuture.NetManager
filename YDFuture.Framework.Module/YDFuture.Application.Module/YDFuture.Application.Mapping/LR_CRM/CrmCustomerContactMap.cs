using YiDaFuture.Application.CRM;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 �ڴ�δ���Ƽ���չ���޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-07-11 09:58
    /// �� �����ͻ���ϵ��
    /// </summary>
    public class CrmCustomerContactMap : EntityTypeConfiguration<CrmCustomerContactEntity>
    {
        public CrmCustomerContactMap()
        {
            #region ������
            //��
            this.ToTable("LR_CRM_CUSTOMERCONTACT");
            //����
            this.HasKey(t => t.F_CustomerContactId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}

