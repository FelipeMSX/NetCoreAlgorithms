using Algorithms.Exceptions;
using Algorithms.Interfaces;
using Algorithms.Helpers;
using System;
using System.Collections.Generic;

namespace Algorithms.Sorts
{

    /*
	Descrição:
		- Aceita valores iguais.
        - O pivô é o elemento do meio.
        - Ordem Crescente.
	*/

    /// <author>Felipe Morais</author>
    /// <email>felipemsx18@gmail.com</email>
    public class QuickSort<T> : IDefaultComparator<T>
    {
		public Comparison<T> Comparator { get; set; }
		
		public QuickSort(Comparison<T> comparator)
		{
			this.Comparator = comparator;
		}

        /// <summary>
        /// Ordena os elementos da lista utilizando a própria lista.
        /// <para>Aceita valores iguais e ordem crescente.</para>
        /// </summary>
        /// <param name="list">Lista de elementos para ordenação.</param>
        /// <exception cref="ComparerNotSetException"/>
        /// <exception cref="NullObjectException"/>
        public void Sort(IList<T> list)
		{
            //validações
            if (Comparator == null)
                throw new ComparerNotSetException();
            if (list == null)
                throw new NullObjectException();

            Quicksort(list, 0, list.Count -1);
		}

		private void Quicksort(IList<T> list, int init, int end)
		{
			if (init < end)
			{
				int pivot = Partition(list, init, end);
				Quicksort(list, init, pivot - 1);
				Quicksort(list, pivot + 1, end);
			}
		}

		private int Partition(IList<T> list, int init, int end)
		{
			int positionPivot = DefinePivot(init, end);
			//Ao definir o pivô é preciso colocá-lo no fim.
			ListFunctions.Swap(list, end, positionPivot);
			positionPivot = end;
			int left = init;
			int right = end - 1;

            // Rodar enquato left&right não se cruzarem no vetor.
            // Varra com left da esquerda para direita o vetor até encontrar o elemento maior que o pivô.
            // Varra com right da direita para esquerda o vetor até encontrar o elemento menor que o pivô.
            while (left <= right)
            {
                while ((left <= right) && Comparator(list[left], list[positionPivot]) <= 0)
                    left++;

                while ((left <= right) && Comparator(list[right], list[positionPivot]) > 0)
                    right--;

                if (left < right)
                {
                    ListFunctions.Swap(list, left, right);
                }
                else
                {
                    ListFunctions.Swap(list, left, positionPivot);
                    positionPivot = left;
                }
            }
            return positionPivot;
        }

        /// <summary>
        /// Define qual pivô vai ser selecionado.
        /// </summary>
        /// <param name="init">Posição inicial do vetor.</param>
        /// <param name="end">Posição final da lista.</param>
        /// <returns>Retorna o elemento do meio.</returns>
		private static int DefinePivot(int init, int end)
		{
			return init + (end - init) / 2;
		}
	}
}
