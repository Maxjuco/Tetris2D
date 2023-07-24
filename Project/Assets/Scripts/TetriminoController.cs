using UnityEngine;

public class TetriminoController : MonoBehaviour
{
    private float lastTimePosition = 0f;

    public Vector2 positionLastBlock;

    private void Awake()
    {
        tag = "Player";
    }

    private void Update()
    {
        PieceControll();
    }

    private void PieceControll()
    {
        //horizontal movement :
        if(Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            transform.position += Vector3.left;
            if (IsValidGridPosition())
                UpdateGridState();
            else
                transform.position += Vector3.right; 
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            if (IsValidGridPosition())
                UpdateGridState();
            else
                transform.position += Vector3.left;
        }
        //rotation : 
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0,0,-90));
            if (IsValidGridPosition())
                UpdateGridState();
            else
                transform.Rotate(new Vector3(0, 0, 90));

        }
         
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastTimePosition >= 1f)
        {
            transform.position += Vector3.down;

            if (IsValidGridPosition())
                UpdateGridState();
            else //the piece can't go down anymore 
            {
                transform.position += Vector3.up;
                //check if we can delete rows : 
                GameGrid.instance.LowerAllRows();
                //if game over : the position is the same as the spawn point 
                if (GameOverManager())
                {

                }
                else
                {
                    //make spawn an other piece :
                    FindObjectOfType<SpawnPiece>().SpawnRandomTetramino();
                }
                //desactivate controlls on the piece : 
                this.enabled = false;
                //take back the player tag to avoid desactivate set pieces during the pause : 
                tag = "Untagged";
            }
            lastTimePosition = Time.time;
        }
    }

    private bool IsValidGridPosition()
    {
        foreach(Transform block in transform)
        {
            Vector2 positionRounded = new Vector2(Mathf.Round(block.position.x), Mathf.Round(block.position.y));

            if (!GameGrid.instance.ValidGridPosition(positionRounded))
                return false;

            //if collide with an other block from an other piece (to avoid block when blocks moving in the same piece): 
            if (GameGrid.instance.grid[(int)positionRounded.x, (int)positionRounded.y] != null
                && GameGrid.instance.grid[(int)positionRounded.x, (int)positionRounded.y].parent != transform)
                return false;
        }

        return true;
    }

    private void UpdateGridState()
    {
        //erase old blocks position : 
        for(int y = 0; y < GameGrid.instance.GetColumns(); y++)
        {
            for (int x = 0; x < GameGrid.instance.GetRows(); x++)
            {
                if(GameGrid.instance.grid[x, y] != null)
                {
                    if(GameGrid.instance.grid[x, y].parent == transform)
                    {
                        GameGrid.instance.grid[x, y] = null;
                    }
                }
                
            }
        }

        //add the new position in the grid : 
        foreach(Transform block in transform)
        {
            Vector2 positionRounded = new Vector2(Mathf.Round(block.position.x), Mathf.Round(block.position.y));
            GameGrid.instance.grid[(int)positionRounded.x, (int)positionRounded.y] = block;
            positionLastBlock = positionRounded;
        }
    }

    private bool GameOverManager()
    {
        Vector3 spawnPoint = FindObjectOfType<SpawnPiece>().transform.position;
        if (transform.position == spawnPoint)
            return true;

        return false;
    }
}
