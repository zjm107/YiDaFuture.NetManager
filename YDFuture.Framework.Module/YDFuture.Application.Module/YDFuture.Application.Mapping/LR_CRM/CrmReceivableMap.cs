using YiDaFuture.Application.CRM;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 �ڴ�δ���Ƽ���չ���޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-07-11 14:48
    /// �� ����Ӧ���˿�
    /// </summary>
    public class LR_CRM_ReceivableMap : EntityTypeConfiguration<CrmReceivableEntity>
    {
        public LR_CRM_ReceivableMap()
        {
            #region ������
            //��
            this.ToTable("LR_CRM_RECEIVABLE");
            //����
            this.HasKey(t => t.F_ReceivableId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}

