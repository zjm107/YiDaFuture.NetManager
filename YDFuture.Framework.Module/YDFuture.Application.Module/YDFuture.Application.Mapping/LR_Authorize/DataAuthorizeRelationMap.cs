using YiDaFuture.Application.Base.AuthorizeModule;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 �ڴ�δ���Ƽ���չ���޹�˾
    /// �� ���������ܿ�����
    /// �� �ڣ�2017-06-21 16:30
    /// �� ��������Ȩ��
    /// </summary>
    public class LR_Base_DataAuthorizeRelationMap : EntityTypeConfiguration<DataAuthorizeRelationEntity>
    {
        public LR_Base_DataAuthorizeRelationMap()
        {
            #region ������
            //��
            this.ToTable("LR_BASE_DATAAUTHORIZERELATION");
            //����
            this.HasKey(t => t.F_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}

