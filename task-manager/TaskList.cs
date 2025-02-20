using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    public class Node<T>
    {
        T m_data;
        Node<T> m_next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }

        public T Data 
        {
            get { return m_data; }
            set { m_data = value; } 
        }
        public Node<T> Next
        {
            get { return m_next; }
            set { m_next = value; }
        }
    }


    public class TaskList<T> where T : Task
    {
        private Node<T> m_head;

        public TaskList()
        {
            m_head = null;
        }


        //properties
        public Node<T> Head {
            get {return m_head;}
        }
       

        public void AddTask(T task)
        {
            Node<T> newNode = new Node<T>(task);
            if (m_head == null)
            {
                m_head = newNode;
            }
            else
            {
                Node<T> current = m_head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public bool RemoveTask(int taskId)
        {
            if (m_head == null) return false;

            if (m_head.Data.TaskID == taskId)
            {
                m_head = m_head.Next;
                return true;
            }

            Node<T> current = m_head;
            Node<T> previous = null;

            while (current != null && current.Data.TaskID != taskId)
            {
                previous = current;
                current = current.Next;
            }

            if (current == null) return false;

            previous.Next = current.Next;
            return true;
        }

        
        public T FindAtID(int taskId)
        {
            Node<T> current = m_head;
            while (current != null)
            {
                if (current.Data.TaskID == taskId)
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null; 
        }
    }
}
