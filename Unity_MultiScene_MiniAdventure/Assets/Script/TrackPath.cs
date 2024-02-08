using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TrackPath : MonoBehaviour
{
    public GameObject PathObject;
    public GameObject PathParent;
    private List<string> Pathlist = new List<string>();
//パスの表示を少しゆっくり見せたいとき
    public int frameInterval = 30; // 何フレームごとに処理するか
    private int currentIndex = 0; // 現在のインデックス
    private int frameCount = 0; // 現在のフレームカウント

    void Start()
    {
        GameObject DataContainerObject = GameObject.Find("DataContainer");
        Pathlist = DataContainerObject.GetComponent<DataContainer>().PathList;
        Debug.Log(string.Join(",", Pathlist)); 
    }
//pathlistに格納されている文字をもとにprefabを配置する
    void Update()
    {
        // フレームカウントを更新
        frameCount++;

        // 指定したフレーム間隔ごとに処理
        if (frameCount >= frameInterval)
        {
            if (currentIndex >= Pathlist.Count)
            {
                return;
                //currentIndex = 0; // 配列の最後に到達したら、最初に戻る
            }else{
                // 現在のオブジェクトを処理
                SetTransform_CreatePrefabInstance(Pathlist[currentIndex]);
                // 次のオブジェクトに進む
                currentIndex++;
            }

            // フレームカウントをリセット
            frameCount = 0;
        }
    }

    private void SetTransform_CreatePrefabInstance(string direction){
        if(direction.Equals("Straight")){
            Vector3 position = new Vector3(0.0f,2.05f,0.0f);
            Vector3 rotation = new Vector3(0.0f,0.0f,0.0f);
            PathParent = CreatePrefabInstance(position,rotation,PathParent.transform);
        }else if(direction.Equals("Right")){
            Vector3 position = new Vector3(0.85f,1.0f,0.5f);
            Vector3 rotation = new Vector3(0.0f,0.0f,-90.0f);
            PathParent = CreatePrefabInstance(position,rotation,PathParent.transform);
        }else if(direction.Equals("Left")){
            Vector3 position = new Vector3(-0.85f,1.0f,0.5f);
            Vector3 rotation = new Vector3(0.0f,0.0f,90.0f);
            PathParent = CreatePrefabInstance(position,rotation,PathParent.transform);
        }
    }

    private GameObject CreatePrefabInstance(Vector3 localPosition, Vector3 localRotation, Transform parent)
{
    // プレハブをインスタンス化（とりあえず、ワールド座標で）
    GameObject instance = Instantiate(PathObject, Vector3.zero, Quaternion.identity, parent);

    // ローカル座標とローカル回転を設定
    instance.transform.localPosition = localPosition;
    instance.transform.localRotation = Quaternion.Euler(localRotation);

    return instance;
}

}
