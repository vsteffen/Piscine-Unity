using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Path {
    //Variable declaration
    //Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
    public int heuristic;
    public List<Checkpoint> path;
   
    //Constructor (not necessary, but helpful)
    public Path(int heuristic, List<Checkpoint> path) {
        this.heuristic = heuristic;
        this.path = path;
    }
}

public class PathFinding : MonoBehaviour {

	public List<Checkpoint>		checkpoints;
	// Use this for initialization

	public List<Checkpoint> GetPath(Checkpoint actualEnemyCheckpoint, int id_room) {
		List<Checkpoint> 	path = new List<Checkpoint> {actualEnemyCheckpoint};
		int					heuristicFinal = 0;
		Path				bestPath;
		Path plop = new Path(0, path);
		bestPath = Explore(id_room, plop);
		return (bestPath.path);

        
	}

	private Path Explore(int id_room, Path path) {
		Path bestPath = new Path(10000, null);
		foreach (Checkpoint cp in path.path[path.path.Count - 1].connections)
		{
			if (path.path.Contains(cp))
				continue;
			if (cp.id_room == id_room)
			{
				List<Checkpoint> 	newPath = new List<Checkpoint>(path.path);
				newPath.Add(cp);
				return (new Path(path.heuristic + 1, newPath));
			}
			else
			{
				List<Checkpoint> 	newPath = new List<Checkpoint>(path.path);
				newPath.Add(cp);
				Path thisPath = Explore(id_room, new Path(path.heuristic + 1, newPath));
				if (thisPath.path != null)
					if (bestPath.path == null || thisPath.heuristic < bestPath.heuristic)
						bestPath = thisPath;
			}
		}
		return bestPath;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
