using Algorithms.Exceptions;
using Algorithms.Interfaces;
using System;
using System.Collections.Generic;

namespace Algorithms.Searchs
{

    /// <summary>
    /// 
    /// </summary>
    /// <author>Felipe Morais</author>
	/// <email>felipeprodev@gmail.com</email>
    public class Search<T> : ISearch<T>
	{
        /// <summary>
        /// Define um comparador padrão para o objeto de entrada.
        /// </summary>
        public Comparison<T> Comparator{ get; set; }

        /// <param name="comparator">Comparador utilizado nos objetos</param>
        public Search(Comparison<T> comparator)
        {
            this.Comparator = comparator;
        }
        /// <summary>
        /// Utiliza a busca binária para encontrar um objeto no vetor.
        /// O vetor deve estar ordenado para funcionar.
        /// <para> Complexidade de Espaço: Melhor -  Médio - Pior - </para>
        /// <para> Complexidade de Tempo: Melhor -  Médio - Pior -</para>
        /// </summary>
        /// <exception cref="NullObjectException">Objeto de entrada não pode ser nulo.</exception>
        /// <exception cref="ComparerNotSetException">Comparator não deve ser nulo.</exception>
        /// <param name="orderedArray">Array com itens ordenados.</param>
        /// <param name="item">Objeto almejado.</param>
        /// <returns>Retorna o objeto caso exista, caso contrário, valor padrão do objeto.</returns>

        public T BinarySearch(IList<T> orderedArray, T item)
		{
            //5 + (7c)N/2   
            //Validações
            if (Comparator == null)
                throw new ComparerNotSetException();
            else if (item == null || orderedArray == null)
                throw new NullObjectException();

            int left = 0;
			int right = orderedArray.Count - 1;
            while (left <= right)
			{
                int mid = MidPosition(left, right);
                // Se o valor do item a ser achado for maior ao do array é necessário avançar para direita.
                // arrayItem < item

                if (Comparator(orderedArray[mid], item) <= -1)
					left = mid + 1;
				else
				// Se o valor do item a ser achado for menor ao do array é necessário avançar para esquerda.
				// arrayItem > item
				if (Comparator(orderedArray[mid], item) >= 1)
					right = mid - 1;
				else
					return orderedArray[mid];
			}
			return default;
		}

        /// <summary>
        /// <para> Complexidade de Espaço: Melhor - 3; Médio - 3; Pior - 3. Notação O(1). </para>
        /// <para> Complexidade de Tempo: Melhor - 0; Médio - 0; Pior - 0. Notação O(1).</para>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static int MidPosition(int left, int right)
		{
			return left + (right - left) / 2;
		}
	}
}
