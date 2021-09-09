module ProjectC

open System
open LinAlgDat.Core

type AdvancedOps = class

    /// <summary>
    ///     This function creates the square submatrix given a square matrix as
    ///     well as row and column indices to remove from it.
    /// </summary>
    /// <remarks>
    ///     See page 246-247 in "Linear Algebra for Engineers and Scientists"
    ///     by K. Hardy.
    /// </remarks>
    /// <param name="A">An N-by-N matrix.</param>
    /// <param name="i">The index of the row to remove.</param>
    /// <param name="j">The index of the column to remove.</param>
    /// <returns>The resulting (N - 1)-by-(N - 1) submatrix.</returns>
    static member SquareSubMatrix (A : Matrix) (i : int) (j : int) : Matrix =
        let m_rows = A.M_Rows
        let n_cols = A.N_Cols
        let mutable M = Matrix(m_rows-1, n_cols-1)
        let ssm_rows = M.M_Rows
        let mutable tempvar = 0

        for K in 0..m_rows-1 do
          let mutable tempRow = []
          if K = i then //excludes the i row
            tempvar <- -1
          else
            for L in 0..n_cols-1 do
              if L = j then //excludes the j column
                ()
              else 
                tempRow <- tempRow @ [(A.[K,L])] //create a temporary row to apply to M for the respective row K
            for V in 0..ssm_rows-1 do
              M.[(K + tempvar),V] <- tempRow.[V]
        M

    static member ElementaryRowReplacement (A : Matrix) (i : int) (m : float) (j : int) : Matrix =
        let n_cols = A.N_Cols
        let rowI = A.Row(i)
        let rowJ = A.Row(j)
        let result = A
        
        for k in 0..n_cols-1 do
            A.[i,k] <- rowI.[k] + rowJ.[k] * m
        result

    static member ElementaryRowInterchange (A : Matrix) (i : int) (j : int) : Matrix =
        let n_cols = A.N_Cols
        let result = Matrix (A)
        
        for k in 0..n_cols-1 do
            //række i <- række j
            result.[i,k] <- A.[j,k]
            //række j <- række i
            result.[j,k] <- A.[i,k]
            
        result

    static member ForwardReduction (M : Matrix) : Matrix =
        let mutable result = Matrix (M)
        let m_rows = M.M_Rows
        let n_cols = M.N_Cols
        let tolerance = 0.00000001

        let rec PivotFinder (indexRow : int) (indexCol : int) =
            let mutable i = indexRow
            let mutable PivotNotFound = true
            //in case the recursive functions goes out of bounds
            if indexRow >= m_rows || indexCol >= n_cols then
                ()
            else
                //looking for the pivot element
                while PivotNotFound = true && i < m_rows do
                    if abs(result.[i, indexCol] - 0.0) > tolerance then //-0.0 due to a bug in the abs method. Without it one test would fail
                        PivotNotFound <- false
                    else
                        i <- i + 1

                match PivotNotFound with
                    //no element was found, try again next col
                    | true  ->  PivotFinder indexRow (indexCol + 1)
                    //element was found - get 0s below pivot
                    | false ->  for j in i+1..m_rows-1 do
                                    let mvalue = -(result.[j, indexCol]/result.[i, indexCol])
                                    result <- AdvancedOps.ElementaryRowReplacement result j mvalue i
                                //if the pivotrow is not right below the previous pivotrow then move it via interchange
                                if i > indexRow then
                                    result <- AdvancedOps.ElementaryRowInterchange result indexRow i
                                else
                                    ()
                                //look for more pivotelements but below and to the right of the one just found
                                PivotFinder (indexRow+1) (indexCol+1)
        in PivotFinder 0 0        
        result

    /// <summary>
    ///     This function computes the determinant of a given square matrix.
    /// </summary>
    /// <remarks>
    ///     See page 247 in "Linear Algebra for Engineers and Scientists"
    ///     by K. Hardy.
    /// </remarks>
    /// <remarks>
    ///     Hint: Use SquareSubMatrix.
    /// </remarks>
    /// <param name="A">An N-by-N matrix.</param>
    /// <returns>The determinant of the matrix</returns>
    static member Determinant (A : Matrix) : float =
        let m_rows = A.M_Rows
        let n_cols = A.N_Cols
        let mutable result = 0.0
        
        let DetTwoByTwo (B : Matrix) =
            (B.[0,0] * B.[1,1]) - (B.[0,1] * B.[1,0])

        if m_rows = 1 then //one by one matrix
            result <- result + A.[0,0] 
        elif m_rows = 2 then //two by two matrix
            result <- result + DetTwoByTwo A
        elif m_rows = 3 then //three by three matrix
            for j in 0..2 do
               result <- result + ((A.[0,j] * ((-1.0) ** (0.0+(float)j))) * (DetTwoByTwo(AdvancedOps.SquareSubMatrix A 0 j)))
        else 
            let detOfTriangleMatrixFinder = //any matrix bigger than three by three, i.e. four by four matrices and up
                let mutable output = 1.0
                let triangleMatrix = (AdvancedOps.ForwardReduction A)
                let rowsNCols = triangleMatrix.M_Rows
                for k in 0..rowsNCols-1 do
                    output <- output * triangleMatrix.[k,k]
                output
            result <- (detOfTriangleMatrixFinder)
        result

    /// <summary>
    ///     This function computes the Euclidean norm of a Vector. This has been implemented
    ///     in Project A and is provided here for convenience
    /// </summary>
    /// <param name="v">
    ///    A Vector
    /// </param>
    /// <returns>
    ///     Euclidean norm, i.e. (\sum v[i]^2)^0.5
    /// </returns>
    static member VectorNorm (v : Vector) =
        let mutable n2 = 0.0
        for i in 0..v.Size-1 do
            n2 <- n2 + v.[i] * v.[i]
        sqrt n2
    


    /// <summary>
    ///     This function copies Vector 'v' as a column of matrix 'A'
    ///     at column position j.
    /// </summary>
    /// <param name="A">
    ///     An M-by-N matrix.
    /// </param>
    /// <param name="v">
    ///     Vector objects that must be copied in A.
    /// </param>
    /// <param name="j">
    ///     column number.
    /// </param>
    /// <returns>
    ///     An M-by-N matrix after modification.
    /// </returns>
    /// <exception cref="ArgumentException"></exception>
    static member SetColumn (A : Matrix) (v : Vector) (j : int) =
        let mutable result = Matrix A
        for i in 0..A.M_Rows-1 do
            result.[i,j] <- v.[i]
        result


    /// <summary>
    ///     This function computes the Gram-Schmidt process on a given matrix.
    /// </summary>
    /// <remarks>
    ///     See page 229 in "Linear Algebra for Engineers and Scientists"
    ///     by K. Hardy.
    /// </remarks>
    /// <param name="A">
    ///     An M-by-N matrix. All columns are implicitly assumed linear
    ///     independent.
    /// </param>
    /// <returns>
    ///     A tuple (Q,R) where Q is a M-by-N orthonormal matrix and R is an
    ///     N-by-N upper triangular matrix.
    /// </returns>
    static member GramSchmidt (A : Matrix) : Matrix * Matrix =
        let m_rows = A.M_Rows
        let n_cols = A.N_Cols
        let mutable MatrixQ = Matrix (m_rows, n_cols)
        let mutable MatrixR = Matrix (n_cols, n_cols)

        let r00 = AdvancedOps.VectorNorm (A.Column 0)
        MatrixR.[0,0] <- r00
        let q1 = Vector.( * ) ((A.Column 0), 1.0/r00)
        MatrixQ <- AdvancedOps.SetColumn MatrixQ q1 0 //q1
        let mutable listofQs = []
        listofQs <- listofQs @ [q1]
        
        let qMarkFinder (qList : List<Vector>) (u : Vector) (indexCol : int) = 
            let mutable result = Vector u
            let AmountofQs = qList.Length
            if AmountofQs = 1 then //when only q1 is in the list - this step are also done to give a better understanding of how to implement for q3 and up
                MatrixR.[0,indexCol] <- Vector.( * ) (u, qList.[0]) //r12
                result <- Vector.(-) (result,  (Vector.( * ) (MatrixR.[0,indexCol], qList.[0]))) //calculate q2'
                //MatrixR.[1,indexCol] <- AdvancedOps.VectorNorm (result) //r22
                //result <- Vector.( * ) (result, 1.0/MatrixR.[1,indexCol]) //calculate q2
            elif AmountofQs > 1 then //when there is more than just q1 in the list
                for i in 0..AmountofQs-1 do //go through the list of q's to get rnm and q'
                    MatrixR.[i, indexCol] <- Vector.( * ) (u, qList.[i])//all r values in the given column
                    result <- Vector.(-) (result, (Vector.( * ) (MatrixR.[i,indexCol], qList.[i])))
            else //to avoid 
                ()    
            result

        let rec qFinder (qList : List<Vector>) (col : int) = //use to find q and the given r_nn
            let mutable result = (qMarkFinder listofQs (A.Column col) col) //assuming qn' is known letting this function focus on q and if we have reached the last u
            MatrixR.[col, col] <- AdvancedOps.VectorNorm (result) //result is currently qn'
            result <- Vector.( * ) (result, 1.0/MatrixR.[col, col]) // calculate q
            listofQs <- listofQs @ [result]
            MatrixQ <- AdvancedOps.SetColumn MatrixQ result col
            if col >= n_cols-1 then //this is not correct
                ()
            else
                qFinder listofQs (col+1)

        qFinder listofQs 1

        (MatrixQ, MatrixR)        
end

























