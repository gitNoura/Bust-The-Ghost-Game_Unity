using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using UnityEngine.UI;

public class Game : MonoBehaviour{
    public const int width = 13, height = 7;
    public Tile[,] grid = new Tile[width, height];
    public double probabilitycount = 2; 
    public int GhostX, GhostY, counter = 0, lastClickedX, lastClickedY;  double GhostProba = 0;
    public int Oranges = 0, Reds = 3, Yellows = 0, Greens = 0, redDistance = 0;

    public double JointTableProbability(string color, int DistanceFromGhost){ 
        //TABLE A
        if(color.Equals("red") && DistanceFromGhost==0){
            return 0.7;
        }
        if(color.Equals("orange") && DistanceFromGhost==0){
            return 0.2;
        } 
        if(color.Equals("yellow") && DistanceFromGhost==0){
            return 0.05;
        } 
        if(color.Equals("green") && DistanceFromGhost==0){
            return 0.05;
        }

        //TABLE B
        if(color.Equals("red") && (DistanceFromGhost==1 || DistanceFromGhost==2)){
            return 0.3;
        } 
        if(color.Equals("orange") && (DistanceFromGhost==1 || DistanceFromGhost==2)){
            return 0.5;
        }
        if(color.Equals("yellow") && (DistanceFromGhost==1 || DistanceFromGhost==2)){
            return 0.15;
        } 
        if(color.Equals("green") && (DistanceFromGhost==1 || DistanceFromGhost==2)){
            return 0.05;
        } 
        
        //TABLE C
        if(color.Equals("red") && (DistanceFromGhost==3 || DistanceFromGhost==4)){
            return 0.05;
        }
        if(color.Equals("orange") && (DistanceFromGhost==3 || DistanceFromGhost==4)){
            return 0.15;
        }
        if(color.Equals("yellow") && (DistanceFromGhost==3 || DistanceFromGhost==4)){
            return 0.5;
        }  
        if(color.Equals("green") && (DistanceFromGhost==3 || DistanceFromGhost==4)){
            return 0.3;
        } 
         
        //TABLE D
        if(color.Equals("red") && DistanceFromGhost>=5){
            return 0.05;
        } 
        if(color.Equals("orange") && DistanceFromGhost>=5){
            return 0.15;
        } 
        if(color.Equals("yellow") && DistanceFromGhost>=5){
            return 0.3;
        } 
        if(color.Equals("green") && DistanceFromGhost>=5){
            return 0.5; 
        } 
        
        return 0;
    }

    void Start(){ 
        GhostPosition();
    }

    public int CalculateDistance(int x, int y, int X, int Y){
        int DistanceX=0, DistanceY=0, Distance;
        if(x>=X){
                DistanceX = x-X;
            } 
            else{
                DistanceX = X-x;
            } 
            if(y>=Y){
                DistanceY = y-Y;
            } 
            else{
                DistanceY = Y-y;
            } 
            Distance=DistanceX+DistanceY;
            return Distance;
    }

    public void CheckInputGrid(){ 
        int Distance=0;
        if(Input.GetButtonDown("Fire1")){ 
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int a = Mathf.RoundToInt(mousePosition.x);
            int b = Mathf.RoundToInt(mousePosition.y);
            if(a> width || b > height){      
                return;
            }
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int x = Mathf.RoundToInt(mousePosition.x);
            int y = Mathf.RoundToInt(mousePosition.y);
            lastClickedX=x; lastClickedY=y;
            
            Distance = CalculateDistance(x, y, GhostX, GhostY);

            Tile tile = grid[x, y];
            tile.SetIsCovered(false);

            if(JointTableProbability("green", Distance)>=0.5){ 
                grid[x,y].probability.text=Math.Round(((JointTableProbability("green", Distance)*0.05))/91,4).ToString();
                int G = Greens;
                redDistance=Distance;
                for (int yy = 0 ; yy < height; yy++){ 
                    for (int xx = 0; xx < width; xx++){                                 
                        if(xx != lastClickedX && yy != lastClickedY){ 

                            Distance = CalculateDistance(xx, yy, GhostX, GhostY);

                            if(JointTableProbability("green", Distance) >= 0.5){
                                grid[xx,yy].probability.text=Math.Round((JointTableProbability("green", Distance)*0.05)/Greens,5).ToString(); 
                            }
                            if(JointTableProbability("yellow", Distance)>=0.5){
                                grid[xx,yy].probability.text=Math.Round((JointTableProbability("yellow", Distance)*0.15)/(91-Yellows),4).ToString();
                            } 
                            if(JointTableProbability("orange", Distance)>=0.5){
                                grid[xx,yy].probability.text=Math.Round((JointTableProbability("orange", Distance)*0.3)/(91-Oranges),4).ToString();
                            } 
                            if(JointTableProbability("red", Distance)>=0.5){
                                grid[xx,yy].probability.text=Math.Round((JointTableProbability("red", Distance)*0.5),4).ToString();
                            } 
                        }
                    }
                }            
            } 
            else if (JointTableProbability("yellow", Distance)>=0.5){
                grid[x,y].probability.text=Math.Round(((JointTableProbability("yellow", Distance)*0.15))/Yellows, 4).ToString();
                redDistance=Distance;
                for(int yy =0 ; yy< height; yy++){ 
                    for(int xx = 0; xx < width; xx++){
                        if(xx!= lastClickedX && yy!= lastClickedY){   

                            Distance = CalculateDistance(xx, yy, GhostX, GhostY);

                            if(JointTableProbability("yellow", Distance)>=0.5){
                                grid[xx,yy].probability.text=Math.Round((JointTableProbability("yellow", Distance)*Distance/(Distance*Greens)), 4).ToString();
                            } 
                            if(JointTableProbability("green", Distance)>=0.5){
                                grid[xx,yy].probability.text=Math.Round((JointTableProbability("green", Distance)*1/(Distance*Greens)), 4).ToString();
                            }  
                            if(JointTableProbability("orange", Distance)>=0.5){
                            grid[xx,yy].probability.text=Math.Round((JointTableProbability("orange", Distance)*1/(Distance*Oranges)), 4).ToString(); 
                            } 
                            if(JointTableProbability("red", Distance)>=0.5){
                                grid[xx,yy].probability.text=Math.Round((JointTableProbability("red", Distance)*0.6), 3).ToString();
                            }
                        }
                    }
                }
            }
            else if (JointTableProbability("orange", Distance)>=0.5){
                grid[x,y].probability.text=Math.Round((JointTableProbability("orange", Distance)*Distance/(Distance*Greens )), 3).ToString();
                redDistance = Distance;
                if(counter<height){
                    counter++;
                } 
                for (int yy =0 ; yy< height; yy++){ 
                    for (int xx = 0; xx < width; xx++){
                        if(xx!= lastClickedX && yy!= lastClickedY){   

                            Distance = CalculateDistance(xx, yy, GhostX, GhostY);

                            if(JointTableProbability("yellow", Distance)>=0.5){
                                grid[xx,yy].probability.text=Math.Round((JointTableProbability("yellow", Distance)*1/(Distance+Yellows)), 3).ToString();
                            }   
                            if(JointTableProbability("green", Distance)>=0.5){
                                grid[xx,yy].probability.text=Math.Round((JointTableProbability("green", Distance)*1/(Distance*Greens))/Oranges, 4).ToString();
                            }  
                            if(JointTableProbability("red", Distance)>=0.5){
                                if(GhostProba<1){
                                    grid[xx,yy].probability.text=Math.Round(Greens/91+(counter-0.05)/height,3).ToString();
                                    GhostProba=Greens/91+(counter-0.05)/height;
                                }  
                            }  
                            if(JointTableProbability("orange", Distance)>=0.5){ 
                                grid[xx,yy].probability.text=Math.Round((JointTableProbability("orange", Distance)*Distance/(Distance*Oranges*Oranges)),3).ToString();
                            } 
                        }
                    }
                }
            }
            else{ 
                grid[x,y].probability.text=Math.Round((JointTableProbability("red", Distance)+0.3),3).ToString();
                for (int yy =0 ; yy< height; yy++){ 
                    for (int xx = 0; xx < width; xx++){
                        if(xx!= lastClickedX && yy!= lastClickedY){   

                            Distance = CalculateDistance(xx, yy, GhostX, GhostY);

                            if(JointTableProbability("yellow", Distance)>=0.5){
                                grid[xx,yy].probability.text=Math.Round(((JointTableProbability("yellow", Distance)*1/(Distance))/91),4).ToString();
                            }  
                            if(JointTableProbability("orange", Distance)>=0.5){
                                grid[xx,yy].probability.text=Math.Round(((JointTableProbability("orange", Distance)*1/(Distance))/91),4).ToString();
                            }   
                            if(JointTableProbability("green", Distance)>=0.5){
                                grid[xx,yy].probability.text=Math.Round(((JointTableProbability("green", Distance)*1/(Distance))/91),4).ToString();
                            }
                        }
                    }
                }
            } 
        }
    }
  
    public void GhostPosition(){ 
        int x = UnityEngine.Random.Range(0, width);
        int y = UnityEngine.Random.Range(0, height);
        if( grid[x, y] == null){ 
            Tile ghostTile =  Instantiate(Resources.Load("Prefabs/red", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
            grid[x, y]=ghostTile;
            GhostX=x; GhostY=y;
            Debug.Log("("+GhostX+", "+ GhostY+ ")");
            NoisyPrintPosition();
            ColorPosition(x, y);
        }
        else{ 
            GhostPosition();
        }
    }

    public void NoisyPrintPosition(){
        int x = UnityEngine.Random.Range(0, width);
        int y = UnityEngine.Random.Range(0, height);
        if( grid[x, y]==null){ 
            Tile noisyPrint =  Instantiate(Resources.Load("Prefabs/red", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
            grid[x, y]=noisyPrint;
        }
        else{ 
            NoisyPrintPosition();
        }
    }
    
    public void ColorPosition(int X, int Y){   
        int Distance = 0;
        for (int y =0 ; y < height; y++){ 
            for (int x = 0; x < width; x++){
                Distance = CalculateDistance(x, y, X, Y);
                if(JointTableProbability("green", Distance)>=0.5 && JointTableProbability("yellow", Distance)<0.5 && JointTableProbability("orange", Distance)<0.5 && grid[x,y]==null){ 
                    Tile color =  Instantiate(Resources.Load("Prefabs/green", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
                    grid[x, y]=color;
                    Greens++;
                } 
                else if (JointTableProbability("yellow", Distance)>=0.5 && grid[x,y]==null){
                    Tile color =  Instantiate(Resources.Load("Prefabs/yellow", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
                    grid[x, y]=color;
                    Yellows++;
                }
                else if (JointTableProbability("orange", Distance)>=0.5  && grid[x,y]==null){
                    Tile color =  Instantiate(Resources.Load("Prefabs/orange", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;
                    grid[x, y]=color;
                    Oranges++;
                }
            }
        }
    }
}