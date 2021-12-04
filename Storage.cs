using System;
using System.Collections.Generic;
using System.Text;

namespace bless_n_keep4._1
{
	class Item
	{
		public Circle C;
		public Item prev;
		public Item next;
		public Item(Circle C)
		{
			this.C = C;
			prev = null;
			next = null;
		}
	};

	class Storage
	{
		private Item first;
		private Item current;
		private Item last;
		public Storage()
		{
			first = null;
			current = null;
			last = null;
		}
		public int count()
		{
			int res = 0;
			for (firstItem(); !isEoL(); nextItem()) res++;
			return res;
		}
		public void add(Circle C)
		{
			Item item = new Item(C);
			if (first == null)
			{
				first = item;
				current = item;
				last = item;
			}
			else
			{
				last.next = item;
				item.prev = last;
				last = item;
			}
		}
		public void firstItem()
		{
			current = first;
		}
		public void lastItem()
		{
			current = last;
		}
		public void prevItem()
		{
			if (!isEoL()) current = current.prev;
		}
		public void nextItem()
		{
			if (!isEoL()) current = current.next;
		}
		public bool isEoL()
		{
			return current == null;
		}
		public bool isThere(Circle C)
		{
			for (firstItem(); !isEoL(); nextItem())
				if (curItem() == C) return true;
			return false;
		}
		public Circle curItem()
		{
			return current.C;
		}
		public Circle removeC()
		{
			if (current == null) return null;
			Item prev = current.prev;
			Item next = current.next;
			Circle C = current.C;
			if (prev == null && next == null)
			{
				first = null;
				last = null;
			}
			else if (next == null)
			{
				current = prev;
				last = prev;
				last.next = null;
			}
			else if (prev == null)
			{
				current = next;
				first.prev = null;
				first = next;
			}
			else
			{
				current = next;
				prev.next = next;
				next.prev = prev;
			}
			return C;
		}
		~Storage()
		{
			if (first == null) return;
			while (!isEoL())
			{
				Item next = current.next;
				current = next;
			}
		}
	};
}
