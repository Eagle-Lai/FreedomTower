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



namespace cfg.ai
{ 

public sealed partial class IsNotSet :  ai.KeyQueryOperator 
{
    public IsNotSet(JSONNode _json)  : base(_json) 
    {
        PostInit();
    }

    public IsNotSet()  : base() 
    {
        PostInit();
    }

    public static IsNotSet DeserializeIsNotSet(JSONNode _json)
    {
        return new ai.IsNotSet(_json);
    }


    public const int __ID__ = 790736255;
    public override int GetTypeId() => __ID__;

    public override void Resolve(Dictionary<string, object> _tables)
    {
        base.Resolve(_tables);
        PostResolve();
    }

    public override void TranslateText(System.Func<string, string, string> translator)
    {
        base.TranslateText(translator);
    }

    public override string ToString()
    {
        return "{ "
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}
