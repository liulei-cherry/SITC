using System;
using System.Collections.Generic;
using System.Text;

namespace Maintenance.Services
{
    internal enum ParameterType
    {
        Err = -1,
        分类 = 1,
        设备编号 = 2,
        设备or系统名称 = 3,
        英文名称 = 4,
        产品名称 = 5,
        型号 = 6,
        生产厂家 = 7,
        修理厂家 = 8,
        主要参数 = 9,
        设备负责人岗位 = 10,
        序列号 = 11,
        设备证书号码 = 12,
        生产日期 = 13,
        安装日期 = 14,
        大修时间 = 15,
        船检编码 = 16,
        运转率 = 17,
        本设备特殊说明 = 18,
        判断分割标志所在列 = 20,
        序号列 = 30,
        操作名称列 = 31,
        操作描述列 = 32,
        参考文件开始列 = 33,
        PMS项目开始行首列列名 = 39, //用于判断是否当前文档符合要求。
        PMS项目名称 = 40,
        PMS负责人岗位 = 41,
        定时周期 = 42,
        定时前允差 = 43,
        定时后允差 = 44,
        定期周期 = 45,
        周期单位 = 46,
        定期前允差 = 47,
        定期后允差 = 48,
        项目内容 = 49,
        是否船检项目 = 50,
        是否修理项目 = 51,
        CMS编号 = 52,
        可能消耗备件开始列 = 53,
        备件开始行首列列名 = 59, //用于判断是否当前文档符合要求。
        备件显示名 = 60,
        备件别名 = 61,
        规格型号 = 62,
        备件号 = 63,
        历史备件号1 = 64,
        历史备件号2 = 65,
        图号 = 66,
        在图编号 = 67,
        警戒库存 = 68,
        构成数量 = 69,
        计量单位 = 70,
        备注 = 71,
        所在仓库起始列 = 72,
    }

    internal enum ModelType
    {
        Model110 = 1,
        Model120 = 2,
        Err = -1,
    }

    internal enum ConfigValueType
    {
        XYPosition = 1,
        ColumnPosition = 2,
        StringValue = 3,
    }
    internal class ModelConfig
    {
        public ModelType WhichModel;//当前配置的是那个模板的
        public ParameterType WhichParameter;//参数类型，对应Excel的模板各参数
        public string PositionValue;//模板中的参数位置
        public ConfigValueType ValueType;//参数位置是绝对坐标还是列，绝对坐标是false,列是true
        //这个属性是为了以后封装时用的			
        public ModelConfig(ModelType whichModel, ParameterType whichParameter, string positionValue, ConfigValueType isColumnOrXy)
        {
            WhichModel = whichModel;
            WhichParameter = whichParameter;
            PositionValue = positionValue;
            ValueType = isColumnOrXy;
        }
    }

    internal class ModelHelper
    {
        public const string CutOffLineString = "空行,供程序识别,不能删除";
        private Dictionary<ModelType, List<ModelConfig>> dicModelInfo = new Dictionary<ModelType, List<ModelConfig>>();

        public ModelHelper()
        {
            InitModelHelper();
        }
        private void InitModelHelper()
        {
            InitModelHelper(ModelType.Model110);
            InitModelHelper(ModelType.Model120);
        }
        private void InitModelHelper(ModelType toInitModelType)
        {
            switch (toInitModelType)
            {
                case ModelType.Model110:
                    dicModelInfo.Add(ModelType.Model110, Init110Model());
                    return;
                case ModelType.Model120:
                    dicModelInfo.Add(ModelType.Model120, Init120Model());
                    return;
            }
            throw new Exception("没有此模板");
        }

        private List<ModelConfig> Init110Model()
        {
            List<ModelConfig> modelConfigOfModel110 = new List<ModelConfig>();
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.设备or系统名称, "C2", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.英文名称, "C3", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.产品名称, "C4", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.型号, "C5", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.生产厂家, "C6", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.修理厂家, "C7", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.主要参数, "C8", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.设备负责人岗位, "C9", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.序列号, "C10", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.设备证书号码, "C11", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.生产日期, "C12", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.安装日期, "C13", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.大修时间, "C14", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.船检编码, "C15", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.运转率, "C16", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.本设备特殊说明, "C17", ConfigValueType.XYPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.判断分割标志所在列, "2", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.序号列, "1", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.操作名称列, "2", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.操作描述列, "3", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.参考文件开始列, "4", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.PMS项目名称, "2", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.PMS负责人岗位, "3", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.定时周期, "4", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.定时前允差, "5", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.定期周期, "6", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.周期单位, "7", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.定期前允差, "8", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.定期后允差, "9", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.项目内容, "10", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.是否船检项目, "11", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.是否修理项目, "12", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.CMS编号, "13", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.可能消耗备件开始列, "14", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.备件显示名, "1", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.备件别名, "2", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.备件号, "3", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.历史备件号1, "4", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.历史备件号2, "5", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.图号, "6", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.在图编号, "7", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.警戒库存, "8", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.构成数量, "9", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.计量单位, "10", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.备注, "11", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.所在仓库起始列, "12", ConfigValueType.ColumnPosition));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.PMS项目开始行首列列名, "项目代码或序号", ConfigValueType.StringValue));
            modelConfigOfModel110.Add(new ModelConfig(ModelType.Model110, ParameterType.备件开始行首列列名, "备件显示名*", ConfigValueType.StringValue));

            return modelConfigOfModel110;
        }
        private List<ModelConfig> Init120Model()
        {
            List<ModelConfig> modelConfigOfModel120 = new List<ModelConfig>();
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.分类, "C2", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.设备编号, "C3", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.设备or系统名称, "C4", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.英文名称, "C5", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.产品名称, "C6", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.型号, "C7", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.生产厂家, "C8", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.修理厂家, "C9", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.主要参数, "C10", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.设备负责人岗位, "C11", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.序列号, "C12", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.设备证书号码, "C13", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.生产日期, "C14", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.安装日期, "C15", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.大修时间, "C16", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.船检编码, "C17", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.运转率, "C18", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.本设备特殊说明, "C19", ConfigValueType.XYPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.判断分割标志所在列, "2", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.序号列, "1", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.操作名称列, "2", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.操作描述列, "3", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.参考文件开始列, "4", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.PMS项目名称, "2", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.PMS负责人岗位, "3", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.定时周期, "4", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.定时前允差, "5", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.定时后允差, "6", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.定期周期, "7", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.周期单位, "8", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.定期前允差, "9", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.定期后允差, "10", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.项目内容, "11", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.是否船检项目, "12", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.是否修理项目, "13", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.CMS编号, "14", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.可能消耗备件开始列, "15", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.备件显示名, "1", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.备件别名, "2", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.规格型号, "3", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.备件号, "4", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.历史备件号1, "5", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.历史备件号2, "6", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.图号, "7", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.在图编号, "8", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.警戒库存, "9", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.构成数量, "10", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.计量单位, "11", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.备注, "12", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.所在仓库起始列, "13", ConfigValueType.ColumnPosition));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.PMS项目开始行首列列名, "项目代码或序号", ConfigValueType.StringValue));
            modelConfigOfModel120.Add(new ModelConfig(ModelType.Model120, ParameterType.备件开始行首列列名, "备件显示名*", ConfigValueType.StringValue));

            return modelConfigOfModel120;
        }

        public ModelConfig GetValue(ModelType modelType, ParameterType parameterType)
        {
            if (modelType == ModelType.Err || parameterType == ParameterType.Err) return null;

            ModelConfig modelConfig = dicModelInfo[modelType].Find(m => m.WhichParameter == parameterType);
            return modelConfig;
        }

        public string GetAPosition(ModelType modelType, ParameterType parameterType)
        {
            return GetValue(modelType, parameterType).PositionValue;
        }

        public int GetAColumnPostion(ModelType modelType, ParameterType parameterType)
        {
            ModelConfig modelConfig = GetValue(modelType, parameterType);
            if (modelConfig == null)
#if DEBUG
                throw new Exception("当前参数无法获取到配置，参数为：" + parameterType.ToString());
#else
                return -1;
#endif
            string sColumn = modelConfig.PositionValue;
            int iColumn = 0;
            if (string.IsNullOrEmpty(sColumn) || !int.TryParse(sColumn, out iColumn) || iColumn <= 0) return -1;
            return iColumn;
        }
    }
}
