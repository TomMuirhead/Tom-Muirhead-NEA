using System;
using System.Collections.Generic;
using System.Drawing;

namespace Game_AI
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("mapWidth: ");
			int x = Convert.ToInt32(Console.ReadLine());
			Console.Write("mapLength: ");
			int y = Convert.ToInt32(Console.ReadLine());

			GameState gameControl = new GameState(x, y);

			gameControl.Print_State();
		}
	}

	class GameState
	{
		int mapWidth, mapLength;

		string[] player_List;
		string player; // "p1" or "p2"

		string[][,] map;
		string[,] player1_Units;
		string[,] player2_Units;
		string[,] player1_Structures;
		string[,] player2_Structures;

		int turn_Count, maxTurns;

		public GameState(int x, int y)
		{
			mapWidth = x; mapLength = y;
			player_List = new string[] { "p1", "p2" };
			Initial_State();
		}

		void Initial_State()
		{
			maxTurns = 10; // temp maxTurns
			turn_Count = 0;

			map = new string[2][,];
			map[0] = new string[mapWidth, mapLength];
			map[1] = new string[mapWidth, mapLength];

			player1_Units = new string[mapWidth, mapLength];
			player2_Units = new string[mapWidth, mapLength];
			player1_Structures = new string[mapWidth, mapLength];
			player2_Structures = new string[mapWidth, mapLength];

			//Fill tiles
			for (int i = 0; i < mapLength; i++)
			{
				for (int j = 0; j < mapWidth; j++)
				{
					map[0][j, i] = "Empty";
				}
			}

			//Initial cities
			player1_Structures[2, 2] = "p1City";
			map[0][2, 2] = player1_Structures[2, 2];

			player2_Structures[mapWidth-3, mapLength-3] = "p2City";
			map[0][mapWidth-3, mapLength-3] = player2_Structures[mapWidth-3, mapLength-3];

		}

		public void EndTurn()
		{
			turn_Count++;
		}
		public int Turn
		{
			get { return turn_Count % 2; }
		} // = gameState.GetTurn(), 0 = "p1", 1 = "p2"/AI

		public void Print_State()
		{
			for (int i = 0; i < mapLength; i++)
			{
				for (int j = 0; j < mapWidth; j++)
				{
					Console.Write(map[0][j, i] + "\t");
				}
				Console.Write("\n");
			}
		}

		bool GameOver()
		{
			if (turn_Count >= maxTurns)
			{
				return true;
			}
			else
				return false;
		}

		public List<TreeNode<string[]>> GetPossibleMoves()
		{
			List<TreeNode<string[]>> possible_Moves = new List<TreeNode<string[]>>();
			player = player_List[Turn];

			// Get possible moves for player ("p1" / "p2")
			// for each p_Move create TreeNode
			// possible_Moves.Add (p_Move)


			return possible_Moves;
		}


		string[] possible_Actions;
	}

	class Unit_Moves
	{
		string[,] player_Units;
		List<TreeNode<string[]>> moves;

		Unit_Moves(string[,] currentUnits)
		{
			// make deep copy of current Units
			// foreach unit in the array Possible_Moves(i, j)
		}

		void Possible_Moves(int x, int y)
		{
			// check valid move
			// new TreeNode (action, points, parent???)
			// fills moves
		}
	}

	class GameController
	{
		GameState gameState;
		StateTree stateTree;


		GameController()
		{

		}

		public void Play_Action()
		{

		}
	}

	class StateTree<T> // Build a tree to represent moves, branches show possible ways the game could be played
	{
		TreeNode<T> root;
		List<TreeNode<T>> tree = new List<TreeNode<T>>();

		StateTree()
		{
			root = new TreeNode<T>(null, null, null);
			tree.Add(root);
		}

		TreeNode<T> Root{get{return root;} }
		int Count { get { return tree.Count; } }

		void ClearTree()
		{
			foreach (TreeNode<T> node in root.Children)
			{
				node.Parent = null;
			}
			root.Children.Clear();
		}

		public bool AddNode(TreeNode<T> node)
		{
			if (node == null || node.Parent == null || !tree.Contains(node.Parent) || node.Parent.Children.Contains(node))
			{
				return false;
			}
			else
			{
				tree.Add(node);
				node.Parent.AddChild(node);
				return true;
			}
		}
	}


	class TreeNode<T>
	{
		//string action;
		//string points;
		string[] nodeValue;
		TreeNode<T> parent;
		List<TreeNode<T>> children;

		public TreeNode(string action, string points, TreeNode<T> parent)
		{
			this.parent = parent;
			nodeValue = new string[] { action, points };
			children = new List<TreeNode<T>>();
		}

		public string Action
		{
			get { return nodeValue[0]; }
		}
		public string Points
		{
			get { return nodeValue[1]; }
		}
		public TreeNode<T> Parent
		{
			get { return parent; }
			set { parent = value; }
		}
		public List<TreeNode<T>> Children
		{
			get { return children; }
		}

		public void AddChild(TreeNode<T> child) // Add node to current node
		{
			children.Add(child);
			child.Parent = this;
		}

		public bool RemoveChild(TreeNode<T> child) // Removes one node from current node
		{
			if (children.Contains(child)) // check if child node is in children
			{
				child.Parent = null;
				return children.Remove(child);
			}
			else
			{
				return false;
			}
		}

		public void RemoveChildren() // Removes all child nodes from current node
		{
			for (int i = children.Count - 1; i >= 0; i--)
			{
				children[i].Parent = null;
			}
			children.Clear();
		}


	}

}
