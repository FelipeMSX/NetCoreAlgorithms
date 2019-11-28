using Algorithms.Exceptions;
using Algorithms.Interfaces;
using System;
using System.Collections.Generic;

namespace Algorithms.Sorts
{
    /// <summary>
    /// </summary>
    /// <author>Felipe Morais</author>
    /// <email>felipemsx18@gmail.com</email>
    /// <typeparam name="E"></typeparam>
    public class MergeSort<T> : IDefaultComparator<T>
    {
		/// <summary>
		/// Compara dois objetos e retorna um inteiro indicando o grau de comparação entre eles.
		/// </summary>
		public Comparison<T> Comparator{ get; set; }

		/// <summary>
		/// Armazena os objetos que serão utilizados na ordenação. 
        /// No algoritmo do mergesort é necessário ter um vetor para armazenar os elementos.
		/// </summary>
		private IList<T> _vector;

		/// <param name="comparator">Método que compara dois objetos e retorna um inteiro.</param>
		public MergeSort(Comparison<T> comparator)
		{
			Comparator = comparator;
		}

        /// <summary>
        /// Ordena o vetor utilizando o algoritmo do mergesort.
        /// </summary>
        /// <param name="list">Vetor com os objetos genéricos.</param>
        /// <exception cref="ComparerNotSetException"/>
        /// <exception cref="NullObjectException"/>
        public void Sort(IList<T> list)
		{
            //validações
            if (Comparator == null)
                throw new ComparerNotSetException();
            if (list == null)
                throw new NullObjectException();

            Mergesort(list, list.Count);
		}

		private void Mergesort(IList<T> list, int length)
		{
			_vector = new T[length];
			Merge(list, 0, length - 1);
		}

		/// <summary>
		/// Parte recursiva do algoritmo que chama recursivamente a metade esquerda e direita.
		/// O algoritmo só irá parar quando fazer uma divisão com um elemento só, a partir daí o algoritmo retrocede a chamadas anteriores ordenando os elementos devidamente.
		/// </summary>
		/// <param name="list">Vetor com todos os dados.</param>
		/// <param name="init">Índice da posição inicial do vetor.</param>
		/// <param name="end">ìndice da posição final do vetor.</param>
		private void Merge(IList<T> list, int init, int end)
		{
			if(init < end)
			{
				int middle = init + (end - init) / 2;
				Merge(list, init, middle);
				Merge(list, middle + 1, end);
				Intercalate(list, init, middle, end);
			}
		}

		private void Intercalate(IList<T> list, int init, int middle, int end)
		{
			int i = init;
			int j = middle + 1;
			int k = init; // controlador do vetor output, a cada adição no vetor, é incrementado

			while (i <= middle || j <= end)
			{
				// Se já passou do fim, significa que não possui mais elementos do meio pro fim para inserir no vetor
				if (j > end)
					_vector[k++] = list[i++];
				// Se i > meio, significa que não existe mais elementos do inicio ao fim para comparar, agora é só adicionar do meio +1 ao fim.
				else if (i > middle)
					_vector[k++] = list[j++];
				else if (Comparator(list[i], list[j]) <= 0)
					_vector[k++] = list[i++];
				else
					_vector[k++] = list[j++];
			}

			//Copiar os elementos para o vetor entrada
			for (int w = init; w <= end; w++)
				list[w] = _vector[w];
		}

	}
}
