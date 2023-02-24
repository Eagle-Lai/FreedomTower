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



namespace cfg.test
{ 

public sealed partial class DefineFromExcelOne :  Bright.Config.BeanBase 
{
    public DefineFromExcelOne(JSONNode _json) 
    {
        { if(!_json["unlock_equip"].IsNumber) { throw new SerializationException(); }  UnlockEquip = _json["unlock_equip"]; }
        { if(!_json["unlock_hero"].IsNumber) { throw new SerializationException(); }  UnlockHero = _json["unlock_hero"]; }
        { if(!_json["default_avatar"].IsString) { throw new SerializationException(); }  DefaultAvatar = _json["default_avatar"]; }
        { if(!_json["default_item"].IsString) { throw new SerializationException(); }  DefaultItem = _json["default_item"]; }
        { if(!_json["e2"].IsObject) { throw new SerializationException(); }  E2 = test.DemoE2.DeserializeDemoE2(_json["e2"]);  }
        { var __json0 = _json["icons"]; if(!__json0.IsArray) { throw new SerializationException(); } Icons = new System.Collections.Generic.List<string>(__json0.Count); foreach(JSONNode __e0 in __json0.Children) { string __v0;  { if(!__e0.IsString) { throw new SerializationException(); }  __v0 = __e0; }  Icons.Add(__v0); }   }
        PostInit();
    }

    public DefineFromExcelOne(int unlock_equip, int unlock_hero, string default_avatar, string default_item, test.DemoE2 e2, System.Collections.Generic.List<string> icons ) 
    {
        this.UnlockEquip = unlock_equip;
        this.UnlockHero = unlock_hero;
        this.DefaultAvatar = default_avatar;
        this.DefaultItem = default_item;
        this.E2 = e2;
        this.Icons = icons;
        PostInit();
    }

    public static DefineFromExcelOne DeserializeDefineFromExcelOne(JSONNode _json)
    {
        return new test.DefineFromExcelOne(_json);
    }

    /// <summary>
    /// 装备解锁等级
    /// </summary>
    public int UnlockEquip { get; private set; }
    /// <summary>
    /// 英雄解锁等级
    /// </summary>
    public int UnlockHero { get; private set; }
    public string DefaultAvatar { get; private set; }
    public string DefaultItem { get; private set; }
    public test.DemoE2 E2 { get; private set; }
    public System.Collections.Generic.List<string> Icons { get; private set; }

    public const int __ID__ = 528039504;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        E2?.Resolve(_tables);
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
        E2?.TranslateText(translator);
    }

    public override string ToString()
    {
        return "{ "
        + "UnlockEquip:" + UnlockEquip + ","
        + "UnlockHero:" + UnlockHero + ","
        + "DefaultAvatar:" + DefaultAvatar + ","
        + "DefaultItem:" + DefaultItem + ","
        + "E2:" + E2 + ","
        + "Icons:" + Bright.Common.StringUtil.CollectionToString(Icons) + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}
