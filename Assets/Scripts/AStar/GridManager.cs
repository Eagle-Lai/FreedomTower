using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTProject
{
    public class GridManager : MonoBehaviour
    {
        //public static GridManager _instance;

        public static GridManager Instance;
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new GridManager();
        //        }
        //        return _instance;
        //    }
        //}

        /// <summary>
        /// ����
        /// </summary>
        public int numOfRows = 10;
        /// <summary>
        /// ����
        /// </summary>
        public int numOfColums = 10;
        public float gridCellSize = 1;
        public bool showGrid = true;
        public bool showObstacleBlocks = true;

        private Vector3 origin = new Vector3();
        private GameObject[] obstacleList;
        public static Node[,] nodes { get; set; }

        public GameObject objStartCube;

        public GameObject objEndCube;

        public GameObject parent;

        List<Node> pathArray;

        public Vector3 Origin
        {
            get { return this.origin; }
        }

        private void Awake()
        {
            Instance = this;
        }

        public void Init()
        {
            CalculateObstacle();
        }

        public void SetObstacleList(GameObject[] gameObjects)
        {
            obstacleList = gameObjects;
        }

        public void CalculateObstacle()
        {
            nodes = new Node[numOfColums, numOfRows];
                                                                                
            GameObject obj;
            int index = 0;
            for (int i = 0; i < numOfColums; i++)
            {
                for (int j = 0; j < numOfRows; j++)
                {
                    Vector3 cellPos = GetGridCellCenter(index);
                    GameObject obj1 = ResourcesManager.Instance.LoadAndInitGameObject("Cube", parent.transform);
                    obj1.transform.localPosition = cellPos;
                    Node node = new Node(obj1);
                    nodes[i, j] = node;
                    index++;
                }
            }
            //if (obstacleList != null && obstacleList.Length > 0)
            //{
            //    foreach (GameObject data in obstacleList)
            //    {
            //        int indexCell = GetGridIndex(data.transform.position);
            //        int col = GetColumn(indexCell);
            //        int row = GetRow(indexCell);
            //        nodes[row, col].MarkAsObstacle();
            //        nodes[row, col].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            //    }
            //}
            int count = 10;
            for (int i = 0; i < numOfColums; i++)
            {
                for (int j = 0; j < numOfRows; j++)
                {
                    int row = Random.Range(0, 9);
                    int col = Random.Range(0, 9);
                    nodes[row, col].MarkAsObstacle();
                    nodes[row, col].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    nodes[row, col].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    if (count <= 0)
                    {
                        return;
                    }
                    else
                    {
                        count--;
                    }
                }
            }
        }

        public int GetGridIndex(Vector3 pos)
        {
            if (!IsInBounds(pos))
            {
                return -1;
            }
            pos -= Origin;
            int col = (int)(pos.x / gridCellSize);
            int row = (int)(pos.z / gridCellSize);
            return (row * numOfColums + col);
        }

        public bool IsInBounds(Vector3 pos)
        {
            float width = numOfColums * gridCellSize;
            float height = numOfRows * gridCellSize;
            return (pos.x >= Origin.x && pos.x <= Origin.x + width &&
                        pos.x <= Origin.z + height && pos.z >= Origin.z);
        }

        public Vector3 GetGridCellCenter(int index)
        {
            Vector3 cellPosition = GetGridCellPosition(index);
            cellPosition.x += (gridCellSize / 2.0f);
            cellPosition.z += (gridCellSize / 2.0f);
            return cellPosition;
        }

        public Vector3 GetGridCellPosition(int index)
        {
            int row = GetRow(index);
            int col = GetColumn(index);
            float xPosition = col * gridCellSize;
            float zPosition = row * gridCellSize;
            return Origin + new Vector3(xPosition, 0, zPosition);
        }

        public int GetRow(int index)
        {
            return index / numOfColums;
        }

        public int GetColumn(int index)
        {
            return index % numOfColums;
        }

        public void GetNeighbours(Node node, List<Node> neighbours)
        {
            Vector3 neighbourPos = node.position;
            int neighbourIndex = GetGridIndex(neighbourPos);

            int row = GetRow(neighbourIndex);
            int column = GetColumn(neighbourIndex);

            int leftNodeRow = row - 1;
            int leftNodeColumn = column;
            AssignNeighour(leftNodeRow, leftNodeColumn, neighbours);

            leftNodeRow = row + 1;
            leftNodeColumn = column;
            AssignNeighour(leftNodeRow, leftNodeColumn, neighbours);

            leftNodeRow = row;
            leftNodeColumn = column + 1;
            AssignNeighour(leftNodeRow, leftNodeColumn, neighbours);

            leftNodeRow = row;
            leftNodeColumn = column - 1;
            AssignNeighour(leftNodeRow, leftNodeColumn, neighbours);
        }

        private void AssignNeighour(int row, int column, List<Node> neighbors)
        {
            if (row != -1 && column != -1 && row < numOfColums && column < numOfColums)
            {
                Node nodeToAdd = nodes[column, row];
                if (nodeToAdd != null)
                {
                    if (!nodeToAdd.isObstacle)
                    {
                        neighbors.Add(nodeToAdd);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (showGrid)
            {
                DebugDrawGrid(transform.position, numOfRows, numOfColums, gridCellSize, Color.red);
            }
            Gizmos.DrawSphere(transform.position, 0.5f);
            if (showObstacleBlocks)
            {
                Vector3 cellSize = new Vector3(gridCellSize, 1.0f, gridCellSize);
                if (obstacleList != null && obstacleList.Length > 0)
                {
                    foreach (GameObject item in obstacleList)
                    {
                        Gizmos.DrawCube(GetGridCellCenter(GetGridIndex(item.transform.position)), cellSize);
                    }
                }
            }
            if (pathArray == null)
            {
                return;
            }
            if (pathArray.Count > 0)
            {
                int index = 1;
                foreach (Node node in pathArray)
                {
                    if (index < pathArray.Count)
                    {
                        Node nextNode = (Node)pathArray[index];
                        Debug.DrawLine(node.position, nextNode.position, Color.green);
                        index++;
                    }
                }
            }
        }
        public void DebugDrawGrid(Vector3 origin, int numRows, int numCols, float cellSize, Color color)
        {
            float width = (numCols * cellSize);
            float height = numRows * cellSize;

            for (int i = 0; i < numRows; i++)
            {
                Vector3 startPos = origin + i * cellSize * new Vector3(0, 0, 1);
                Vector3 endPos = startPos + width * new Vector3(1, 0, 0);
                Debug.DrawLine(startPos, endPos, color);
            }

            for (int i = 0; i < numCols; i++)
            {
                Vector3 startPos = origin + i * cellSize * new Vector3(1, 0, 0);
                Vector3 endPos = startPos + height * new Vector3(0, 0, 1);
                Debug.DrawLine(startPos, endPos, color);
            }
        }
        public List<Node> GetPath()
        {

            Transform startPos = objStartCube.transform;

            Transform endPos = objEndCube.transform;

            Node startNode = new Node(GetGridCellCenter(GetGridIndex(startPos.localPosition)));
            Node goalNode = new Node(GetGridCellCenter(GetGridIndex(endPos.localPosition)));

            pathArray = AStar.FindPath(startNode, goalNode);
            return pathArray;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GetPath();
            }
        }
    }
}