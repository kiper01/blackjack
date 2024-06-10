using System.Collections.Generic;
using System;

public class Deck
{
    protected class Node
    {
        public Card Data { get; set; }
        public Node Next { get; set; }

        public Node(Card data)
        {
            Data = data;
            Next = null;
        }
    }

    protected Node head;
    protected Node tail;
    protected int count;

    public Deck()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void AddCardToStart(Card card) // task 2
    {
        Node newNode = new Node(card);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
        }
        count++;
    }

    public Card GetCardFromStart() // task 2 (удаление с начала (с возвращением элемента))
    {
        if (head == null) throw new InvalidOperationException("Колода пуста.");

        Card card = head.Data;
        head = head.Next;
        count--;

        return card;
    }

    public void AddCardByIndex(Card card, int index) // task 2
    {
        if (index < 0 || index > count)
        {
            throw new IndexOutOfRangeException("Неверное значение индекса колоды.");
        }

        Node newNode = new Node(card);

        if (index == 0)
        {
            AddCardToStart(card);
            return;
        }
        else if (index == count)
        {
            tail.Next = newNode;
            tail = newNode;
        }
        else
        {
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }

        count++;
    }

    public Card GetCardByIndex(int index) // task 2 (удаление по указанному индексу (с возвращением элемента))
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Неверное значение индекса колоды.");
        }

        if (head == null)
        {
            throw new InvalidOperationException("Колода пуста.");
        }

        if (index == 0)
        {
            return GetCardFromStart();
        }

        Node current = head;
        Node previous = null;

        for (int i = 0; i < index; i++)
        {
            previous = current;
            current = current.Next;
        }

        previous.Next = current.Next;
        if (previous.Next == null)
        {
            tail = previous;
        }

        count--;

        return current.Data;
    }

    public IEnumerable<Card> GetAllCards()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    public int Count => count;

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }
}
