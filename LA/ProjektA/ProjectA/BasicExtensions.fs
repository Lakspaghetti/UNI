module ProjectA

open System
open LinAlgDat.Core

type BasicOps = class
  /// <summary>
  /// This function creates an augmented Matrix given a Matrix A, and a
  /// right-hand side Vector v.
  /// </summary>
  ///
  /// <remarks>
  /// See page 12 in "Linear Algebra for Engineers and Scientists"
  /// by K. Hardy.
  /// </remarks>
  ///
  /// <param name="A">An M-by-N Matrix.</param>
  /// <param name="v">An M-size Vector.</param>
  ///
  /// <returns>An M-by-(N+1) augmented Matrix [A | v].</returns>
  static member AugmentRight (A : Matrix) (v : Vector) : Matrix =
    let m_rows = A.M_Rows
    let n_cols = A.N_Cols

    let retval = Array2D.zeroCreate m_rows (n_cols + 1)

    for i in 0..m_rows-1 do
        for j in 0..n_cols-1 do
            retval.[i, j] <- A.[i, j]
        retval.[i, n_cols] <- v.[i]
    Matrix retval

  /// <summary>
  /// This function computes the Matrix-Vector product of a Matrix A,
  /// and a column Vector v.
  /// </summary>
  ///
  /// <remarks>
  /// See page 68 in "Linear Algebra for Engineers and Scientists"
  /// by K. Hardy.
  /// </remarks>
  ///
  /// <param name="A">An M-by-N Matrix.</param>
  /// <param name="v">An N-size Vector.</param>
  ///
  /// <returns>An M-size Vector b such that b = A * v.</returns>
  static member MatVecProduct (A : Matrix) (v : Vector) : Vector =
    let m_rows = A.M_Rows
    let n_cols = A.N_Cols
    let mutable b = Vector(m_rows)

    for i in 0..m_rows-1 do      
      for j in 0..n_cols-1 do        
        b.[i] <- b.[i] + A.[i,j] * v.[j]        
    b

  /// <summary>
  /// This function computes the Matrix product of two given matrices
  /// A and B.
  /// </summary>
  ///
  /// <remarks>
  /// See page 58 in "Linear Algebra for Engineers and Scientists"
  /// by K. Hardy.
  /// </remarls>
  ///
  /// <param name="A">An M-by-N Matrix.</param>
  /// <param name="B">An N-by-P Matrix.</param>
  ///
  /// <returns>The M-by-P Matrix A * B.</returns>
  static member MatrixProduct (A : Matrix) (B : Matrix) : Matrix =
    let ma_rows = A.M_Rows
    let na_cols = A.N_Cols
    let nb_cols = B.N_Cols
    let mutable C = Matrix(ma_rows, nb_cols)

    for i in 0..ma_rows-1 do //M
      for j in 0..nb_cols-1 do //P
        for k in 0..na_cols-1 do //N
          C.[i,j] <- C.[i,j] + A.[i,k] * B.[k,j] // matrix A is M x N. Matrix B is N x P. Therefor C is M x P
    C

  /// <summary>
  /// This function computes the transpose of a given Matrix.
  /// </summary>
  ///
  /// <remarks>
  /// See page 69 in "Linear Algebra for Engineers and Scientists"
  /// by K. Hardy.
  /// </remarks>
  ///
  /// <param name="A">An M-by-N Matrix.</param>
  ///
  /// <returns>The N-by-M Matrix B such that B = A^T.</returns>
  static member Transpose (A : Matrix) : Matrix =
    let m_rows = A.M_Rows
    let n_cols = A.N_Cols
    let mutable B =  Matrix(n_cols, m_rows) //reverse size

    for i in 0..m_rows-1 do
      for j in 0..n_cols-1 do
        B.[j,i] <- A.[i,j] //transpose the elements
    B

  /// <summary>
  /// This function computes the Euclidean Vector norm of a given
  /// Vector.
  /// </summary>
  ///
  /// <remarks>
  /// See page 197 in "Linear Algebra for Engineers and Scientists"
  /// by K. Hardy.
  /// </remarks>
  ///
  /// <param name="v">An N-dimensional Vector.</param>
  ///
  /// <returns>The Euclidean norm of the Vector.</returns>
  static member VectorNorm (v : Vector) : float =
    let mutable result = 0.0
    let lenght = v.Size

    for i in 0..lenght-1 do
      result <- result + ((v.[i]) ** 2.0)
    sqrt(result)

  /// <summary>
  /// This function creates the square submatrix given a square
  /// Matrix A, as well as row, and column indices to remove from A.
  /// </summary>
  ///
  /// <remarks>
  /// See "square submatrix" on page 246-247 in "Linear Algebra for
  /// Engineers and Scientists" by K. Hardy.
  /// </remarks>
  ///
  /// <param name="A">A square Matrix.</param>
  /// <param name="i">The index of the row to remove from A</param>
  /// <param name="j">The index of the column to remove from A</param>
  ///
  /// <returns>A square submatrix of the Matrix A.</returns>
  static member SquareSubMatrix (A : Matrix) (i : int) (j : int) : Matrix =
    let m_rows = A.M_Rows
    let n_cols = A.N_Cols
    let mutable M = Matrix(m_rows-1, n_cols-1)

    for K in 0..m_rows-1 do
      let mutable tempRow = []
      if K = i then //excludes the i row
        ()
      else
        for L in 0..n_cols-1 do
          if L = j then //excludes the j column
            ()
          else 
            tempRow <- tempRow @ [A.[K,L]] //create a temporary row to apply to M for the respective row K
        for V in 0..m_rows-2 do
          M.[K,V] <- tempRow.[V]
    M

end
