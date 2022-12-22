using UnityEngine;
using System.Collections;

namespace Pathfinding
{
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour
	{
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		public Transform target1;
		public Transform target2;
		private float distance1;
		private float distance2;

		private GameObject player;
		private GameObject tar;
		IAstarAI ai;

		void OnEnable()
		{
			ai = GetComponent<IAstarAI>();
			player = GameObject.FindGameObjectWithTag("Player");
			tar = GameObject.FindGameObjectWithTag("Target");
			target1 = player.transform;
			target2 = tar.transform;
			distance1 = Vector3.Distance(transform.position, target1.position);
			distance2 = Vector3.Distance(transform.position, target2.position);
			if (distance1 >= distance2)
			{
				target = target2;
			}
			else
			{
				target = target1;
			}
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.

			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable()
		{
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update()
		{
			target1 = player.transform;
			target2 = tar.transform;
			distance1 = Vector3.Distance(transform.position, target1.position);
			distance2 = Vector3.Distance(transform.position, target2.position);
			if (distance1 >= distance2)
			{
				target = target2;
			}
			else
			{
				target = target1;
			}
			// Update
			if (target != null && ai != null) ai.destination = target.position;
		}
	}
}
