using Algorithms.Exceptions;
using OmegaCore.Collections;
using OmegaCore.Collections.Interfaces;
using OmegaCore.Interfaces;

namespace Algorithms.Sorts
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public class MergeSort<T> : IOmegaComparator<T>, ISortable<T>
    {
        public OmegaComparison<T> Comparator { get; set; }

        private IOmegaList<T> _internalList;
        private IOmegaList<T> _resultlist;


        public MergeSort(OmegaComparison<T> comparator)
		{
			Comparator = comparator;
		}

        /// <summary>
        /// Orders the collection using the heapsort algorithm.
        /// </summary>
        /// <exception cref="ComparatorNotSetException"/>
        /// <exception cref="NullObjectException"/>
        public void Sort(IOmegaList<T> list)
		{
            //Validations
            OmegaCore.Exceptions.ArgumentNullException.CheckAgainstNull(list, nameof(list));

            if (Comparator == null)
                throw new ComparatorNotSetException();

            _internalList = list;

            Mergesort(list.Count);
		}

		private void Mergesort(int length)
		{
			_internalList = new OmegaList<T>(length);
			Merge(0, length - 1);
		}

		/// <summary>
		/// Parte recursiva do algoritmo que chama recursivamente a metade esquerda e direita.
		/// O algoritmo só irá parar quando fazer uma divisão com um elemento só, a partir daí o algoritmo retrocede a chamadas anteriores ordenando os elementos devidamente.
		/// </summary>
		/// <param name="list">Vetor com todos os dados.</param>
		/// <param name="init">Índice da posição inicial do vetor.</param>
		/// <param name="end">ìndice da posição final do vetor.</param>
		private void Merge( int init, int end)
		{
			if(init < end)
			{
				int middle = init + (end - init) / 2;
				Merge(init, middle);
				Merge( middle + 1, end);
				Intercalate(init, middle, end);
			}
		}

		private void Intercalate( int init, int middle, int end)
		{
			int i = init;
			int j = middle + 1;
			int k = init; // controlador do vetor output, a cada adição no vetor, é incrementado

			//while (i <= middle || j <= end)
			//{
			//	// Se já passou do fim, significa que não possui mais elementos do meio pro fim para inserir no vetor
			//	if (j > end)
			//		_resultlist[k++] = list[i++];
			//	// Se i > meio, significa que não existe mais elementos do inicio ao fim para comparar, agora é só adicionar do meio +1 ao fim.
			//	else if (i > middle)
   //                 _resultlist[k++] = list[j++];
			//	else if (Comparator(list[i], list[j]) <= 0)
   //                 _resultlist[k++] = list[i++];
			//	else
   //                 _resultlist[k++] = list[j++];
			//}

			////Copiar os elementos para o vetor entrada
			//for (int w = init; w <= end; w++)
			//	_internalList[w] = _resultlist[w];
		}

    }
}
