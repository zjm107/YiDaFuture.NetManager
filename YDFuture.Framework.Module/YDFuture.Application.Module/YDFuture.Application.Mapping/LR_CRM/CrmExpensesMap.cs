using YiDaFuture.Application.CRM;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 �ڴ�δ���Ƽ���չ���޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-07-11 14:28
    /// �� ��������֧��
    /// </summary>
    public class CrmExpensesMap : EntityTypeConfiguration<CrmExpensesEntity>
    {
        public CrmExpensesMap()
        {
            #region ������
            //��
            this.ToTable("LR_CRM_EXPENSES");
            //����
            this.HasKey(t => t.F_ExpensesId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}

