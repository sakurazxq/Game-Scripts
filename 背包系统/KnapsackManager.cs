using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackManager : MonoBehaviour
{
    private static KnapsackManager _instance;
    public static KnapsackManager Instance { get { return _instance; } }
    public GridPanelUI GridPanelUI;
    public TooltipUI TooltipUI;
    public DragItemUI DragItemUI;

    private bool isShow = false;
    private bool isDrag = false;

    public Dictionary<int, Item> ItemList { get; private set; }

    void Awake()
    {
        _instance = this;   //单例模式
        Load();

        GridUI.OnEnter += GridUI_OnEnter;
        GridUI.OnExit += GridUI_OnExit;
        GridUI.OnLeftBeginDrag += GridUI_OnLeftBeginDrag;
        GridUI.OnLeftEndDrag += GridUI_OnLeftEndDrag;
    }

    void Update()
    {
        Vector2 position;
        //将鼠标指向的屏幕上的位置的坐标转化为物体坐标并赋值给position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("KnapsackUI").transform as RectTransform, Input.mousePosition, null, out position);

        if (isDrag)
        {
            DragItemUI.Show();   //另外创建的DragItemUI显示
            DragItemUI.SetLocalPosition(position);
        }
        else if (isShow)
        {
            TooltipUI.Show();
            TooltipUI.SetLocalPosition(position);  //设置TooltipUI显示时的坐标
        }
    }

    public void StoreItem(int itemId)
    {
        if (!ItemList.ContainsKey(itemId))
        {
            return;
        }
        
        Transform emptyGrid = GridPanelUI.GetEmptyGrid();    //得到空格子的位置
        if(emptyGrid == null)
        {
            Debug.LogWarning("背包已满！");
            return;
        }
        Item temp = ItemList[itemId];   //通过itemId查找Dictionary中的Item
        this.CreateNewItem(temp, emptyGrid);

        
    }

    private void Load()
    {
        ItemList = new Dictionary<int, Item>();

        Weapon w2 = new Weapon(0, "牛刀", "宰牛刀", 20, 10, "", 100);
        Weapon w1 = new Weapon(1, "金枪", "可以射击", 150, 100, "", 190);

        Consumable c1 = new Consumable(2, "红瓶", "加血", 20, 12, "", 20,0);
        Consumable c2 = new Consumable(3, "蓝瓶", "加蓝", 40, 20, "", 0, 20);

        Armor a1 = new Armor(4, "头盔", "保护头部", 120, 80, "", 5, 40, 1);
        Armor a2 = new Armor(5, "胸甲", "护胸", 200, 100, "", 25, 30, 12);

        ItemList.Add(w1.ID, w1);
        ItemList.Add(w2.ID, w2);
        ItemList.Add(c1.ID, c1);
        ItemList.Add(c2.ID, c2);
        ItemList.Add(a1.ID, a1);
        ItemList.Add(a2.ID, a2);
    }

#region 事件回调
    private void GridUI_OnEnter(Transform gridTransform)
    {
        Item item = ItemModel.GetItem(gridTransform.name);   //得到鼠标下面格子处的item
        if (item == null)
            return;
        TooltipUI.UpdateTooltip(item.Name);
        isShow = true;
    }

    private void GridUI_OnExit()
    {
        isShow = false;
        TooltipUI.Hide();
    }

    private void GridUI_OnLeftBeginDrag(Transform gridTransform)
    {
        if (gridTransform.childCount == 0)
            return;
        else
        {
            Item item = ItemModel.GetItem(gridTransform.name);
            DragItemUI.UpdateItem(item.Name);
            Destroy(gridTransform.GetChild(0).gameObject);
            isDrag = true;
        }
    }

    private void GridUI_OnLeftEndDrag(Transform preTransform,Transform enterTransform)
    {
        isDrag = false;
        DragItemUI.Hide();

        if(enterTransform == null)   //扔东西
        {
            ItemModel.DeleteItem(preTransform.name);
            Debug.LogWarning("物品已扔");
        }
        else if(enterTransform.tag == "Grid")   //拖到格子里
        {
            if (enterTransform.childCount == 0)   //直接扔进去
            {
                Item item = ItemModel.GetItem(preTransform.name);
                this.CreateNewItem(item, enterTransform);
                ItemModel.DeleteItem(preTransform.name);

            }
            else  //交换
            {
                Destroy(enterTransform.GetChild(0).gameObject);
                Item preGridItem = ItemModel.GetItem(preTransform.name);
                Item enterGridItem = ItemModel.GetItem(enterTransform.name);
                this.CreateNewItem(preGridItem, enterTransform);
                this.CreateNewItem(enterGridItem, preTransform);
            }
        }
        else   //拖到缝隙里就还原
        {
            Item item = ItemModel.GetItem(preTransform.name);
            this.CreateNewItem(item, preTransform);
        }
        
    }
#endregion

    private void CreateNewItem(Item item,Transform parent)
    {
        GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/Item");   //找到Prefab
        itemPrefab.GetComponent<ItemUI>().UpdateItem(item.Name);   //将Prefab中的名字设为查找到的Item的名字
        GameObject itemGo = Instantiate(itemPrefab);    //实例化Prefab
        itemGo.transform.SetParent(parent);   //设置实例化后物体的父节点
        itemGo.transform.localPosition = Vector3.zero;   //实例化后物体的相对坐标为0
        itemGo.transform.localScale = Vector3.one;   //相对大小为1
        ItemModel.StoreItem(parent.name, item);  //存储数据
    }
}
