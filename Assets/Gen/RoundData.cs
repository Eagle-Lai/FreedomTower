//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace cfg
{ 

public sealed partial class RoundData :  Bright.Config.BeanBase 
{
    public RoundData(JSONNode _json) 
    {
        { if(!_json["id"].IsNumber) { throw new SerializationException(); }  Id = _json["id"]; }
        { var __json0 = _json["EnemyIndexs"]; if(!__json0.IsArray) { throw new SerializationException(); } EnemyIndexs = new System.Collections.Generic.List<int>(__json0.Count); foreach(JSONNode __e0 in __json0.Children) { int __v0;  { if(!__e0.IsNumber) { throw new SerializationException(); }  __v0 = __e0; }  EnemyIndexs.Add(__v0); }   }
        { if(!_json["interval"].IsNumber) { throw new SerializationException(); }  Interval = _json["interval"]; }
        PostInit();
    }

    public RoundData(int id, System.Collections.Generic.List<int> EnemyIndexs, int interval ) 
    {
        this.Id = id;
        this.EnemyIndexs = EnemyIndexs;
        this.Interval = interval;
        PostInit();
    }

    public static RoundData DeserializeRoundData(JSONNode _json)
    {
        return new RoundData(_json);
    }

    public int Id { get; private set; }
    /// <summary>
    /// 这一场出现的敌人序号
    /// </summary>
    public System.Collections.Generic.List<int> EnemyIndexs { get; private set; }
    /// <summary>
    /// 对应的出现间隔
    /// </summary>
    public int Interval { get; private set; }

    public const int __ID__ = 1998437944;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "EnemyIndexs:" + Bright.Common.StringUtil.CollectionToString(EnemyIndexs) + ","
        + "Interval:" + Interval + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}
