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

public sealed partial class TbItem2
{
    private readonly Dictionary<int, test.ItemBase> _dataMap;
    private readonly List<test.ItemBase> _dataList;
    
    public TbItem2(JSONNode _json)
    {
        _dataMap = new Dictionary<int, test.ItemBase>();
        _dataList = new List<test.ItemBase>();
        
        foreach(JSONNode _row in _json.Children)
        {
            var _v = test.ItemBase.DeserializeItemBase(_row);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, test.ItemBase> DataMap => _dataMap;
    public List<test.ItemBase> DataList => _dataList;

    public T GetOrDefaultAs<T>(int key) where T : test.ItemBase => _dataMap.TryGetValue(key, out var v) ? (T)v : null;
    public T GetAs<T>(int key) where T : test.ItemBase => (T)_dataMap[key];
    public test.ItemBase GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public test.ItemBase Get(int key) => _dataMap[key];
    public test.ItemBase this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    
    partial void PostInit();
    partial void PostResolve();
}

}