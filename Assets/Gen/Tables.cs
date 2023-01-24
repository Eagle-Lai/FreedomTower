//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using SimpleJSON;


namespace cfg
{ 
   
public sealed partial class Tables
{
    public item.TbItem TbItem {get; }
    public TbEquip TbEquip {get; }
    public TBTower TBTower {get; }

    public Tables(System.Func<string, JSONNode> loader)
    {
        var tables = new System.Collections.Generic.Dictionary<string, object>();
        TbItem = new item.TbItem(loader("item_tbitem")); 
        tables.Add("item.TbItem", TbItem);
        TbEquip = new TbEquip(loader("tbequip")); 
        tables.Add("TbEquip", TbEquip);
        TBTower = new TBTower(loader("tbtower")); 
        tables.Add("TBTower", TBTower);
        PostInit();

        TbItem.Resolve(tables); 
        TbEquip.Resolve(tables); 
        TBTower.Resolve(tables); 
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        TbItem.TranslateText(translator); 
        TbEquip.TranslateText(translator); 
        TBTower.TranslateText(translator); 
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}