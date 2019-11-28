using System.Collections.Generic;

namespace Algorithms.Helpers
{
    public static class ListFunctions
	{

        /// <summary>
        /// Faz a troca de dois objetos de um vetor.
        /// </summary>
        /// <typeparam name="E"> Tipo do objeto do vetor.</typeparam>
        /// <param name="list">Vetor de entrada.</param>
        /// <param name="x">Posição onde irá ser feita a troca.</param>
        /// <param name="y">Posição onde irá ser feita a troca.</param>
        public static void Swap<T>(IList<T> list, int x, int y)
        {
            T temp = list[x];
            list[x] = list[y];
            list[y] = temp;
        }
    }
}
