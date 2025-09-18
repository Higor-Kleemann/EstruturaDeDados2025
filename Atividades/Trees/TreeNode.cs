using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trees
{
    public class TreeNode<T> // "<T>"é a especificação de um tipo genérico (Generics)
    {
        public T Data { get; set; }
        // O atributo "Data" do tipo genérico "T" armazena o valor do nó.
        public TreeNode<T> Parent { get; set; }
        // O atributo "Parent" será a referencia ao nó pai da arvore.
        public List<TreeNode<T>> Children { get; set; }
        // O atributo "Children" é uma lista dos nós filhos, tambem do tipo Generic "T".
        public int GetHeight()
        {
            int heigth = 1;
            TreeNode<T> current = this;
            while (current.Parent != null)
            {
                heigth++;
                current = current.Parent;
            }
            return heigth;
        }
    }
}