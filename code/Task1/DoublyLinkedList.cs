using System;

namespace A5.Task1
{
	public class DoublyLinkedList
	{
		private class Node
		{
			public int data;
			public Node next;
			public Node previous;

			public Node(int data, Node next, Node previous)
			{
				this.data = data;
				this.next = next;
				if (next != null)
				{
					next.previous = this;
				}
				this.previous = previous;
				if (previous != null)
				{
					previous.next = this;
				}
			}
			public Node(int data, Node next) : this(data, next, null) { }
			public Node(int data) : this(data, null, null) { }
		}

		private Node head; // Start of the list
		private Node tail; // End of the list

		public void addFront(int value)
		{
			head = new Node(value, head);
			if (tail == null)
			{
				tail = head;
			}
		}

		public void addBack(int value)
		{
			tail.next = new Node(value, null, tail);
			tail = tail.next;
			if (head == null)
			{
				head = tail;
			}
		}

		public int removeFront()
		{
			if (head == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			int temp = head.data;
			head = head.next;
			if (head != null)
			{
				head.previous = null;
			}
			else
			{
				tail = null;
			}
			return temp;
		}

		public int removeBack()
		{
			if (tail == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			int temp = tail.data;
			tail = tail.previous;
			if (tail != null)
			{
				tail.next = null;
			}
			else
			{
				head = null;
			}
			return temp;
		}

		public void add(int value, int index)
		{
			int numElems = size();
			if (index < 0 || index >= numElems)
			{
				throw new IndexOutOfRangeException();
			}
			if (index == 0)
			{
				addFront(value);
			}
			else if (index == numElems)
			{
				addBack(value);
			}
			else
			{
				int count = 0;
				Node temp = head;
				while(count < index)
				{
					temp = temp.next;
					++count;
				}
				temp.next = new Node(value, temp.next, temp);
			}
		}

		public int remove(int index)
		{
			int numElems = size();
			if (index < 0 || index >= numElems)
			{
				throw new IndexOutOfRangeException();
			}
			if (index == 0)
			{
				return removeFront();
			}
			if (index == numElems - 1)
			{
				return removeBack();
			}

			int count = 0;
			Node temp = head;
			while (count < index - 1)
			{
				temp = temp.next;
				++count;
			}

			int tmp = temp.next.data;
			temp.next = temp.next.next;
			if (temp.next != null)
			{
				temp.next.previous = temp;
			}
			return tmp;
		}

		public int size()
		{
			int count = 0;
			Node temp = head;
			while (temp != null)
			{
				++count;
				temp = temp.next;
			}
			return count;
		}

		public int indexOf(int value)
		{
			Node temp = head;
			int idx = 0;
			while (temp != null)
			{
				if (temp.data == value)
				{
					return idx;
				}
				temp = temp.next;
				++idx;
			}
			return -1;
		}

		public bool empty()
		{
			return head == null; 
		}

		public int get(int index)
		{
			if (index < 0 || index >= size())
			{
				throw new IndexOutOfRangeException();
			}

			int count = 0;
			Node temp = head;
			while (count < index)
			{
				temp = temp.next;
				++count;
			}
			return temp.data;
		}

		public int front()
		{
			if (head == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			return head.data;
		}

		public int back()
		{
			if (tail == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			return tail.data;
		}

		public void clear()
		{
			head = null;
			tail = null;
		}
	}
}
