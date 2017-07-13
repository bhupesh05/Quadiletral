using System;

namespace QuadrilateralMadness
{

   class Program
    {    
         class probabilty
        {
            public int events; //count non degenerate quadrilateral
            public int occurance; //count possible combination
            public probabilty()
            {
                   events=0;occurance=0;
            }
            public void print()
            {
                Console.WriteLine("{0}/{1}",events,occurance);
            }

            // Creating all possible combination
				 public void findProbality(int n,int[] L)
				{
				
					for(int a=0;a<n;a++)
					{
						for(int b=0;b<n&&a!=b;b++)
						{
							for(int c=0;c<n&&c!=b;c++)
							{
								for(int d=0;d<n&&d!=c;d++)
								{
									occurance++;
									if(isDegenQuadilateral(L[a],L[b%n],L[c%n],L[d%n]))
									events++;
								}
							}
						}
						
					}

					// setting the fraction numerator and denominator

					int divisor=GCD(events,occurance);
					events/=divisor;
					occurance/=divisor;

				}

					//method to fing divisor of two number
					 public static int GCD(int a, int b)
				{
					return b == 0 ? a : GCD(b, a % b);
				}

        }

        static void Main()
        {
                
             int m; //number of Test case
             
             int n; //number of stick
        
             int[] L; // length of stick 

             probabilty[] output;  //probabilty output

            // input for test cases
            m_input:
            Console.Write("How many test cases 1 to 10: ");
            try
			{
				m= int.Parse(Console.ReadLine());

				if(m<=0||m>=10) throw new Exception();
			}
            catch
            {
              Console.WriteLine("number must be greater than 0 and less than 10");
              goto m_input;  
            }
            
            //defining probabilty Array
            output=new probabilty[m];
            
            while(m-->0)
            {
               output[m]=new probabilty(); //intializing object of probabilty class
               inputsticks(out n,out L);  // getting  input
               output[m].findProbality(n,L); //executing probabilty
            } 

            Array.Reverse(output);

            Console.WriteLine("\nProbability output\n");            
            
            foreach(var result in output)
            {
                result.print();
            }

               
            Console.ReadKey();
        }

 
        //static function for input for stick
        static void inputsticks(out int n,out int[] L)
        { 
            n_input:
            Console.WriteLine("Enter number of Stick");
                 try{
                 n= int.Parse(Console.ReadLine());
                 if(n<=3||n>=1000) throw new Exception();
                 }
                 catch
                 {
                     Console.WriteLine("number of stick must be with in range 3 to 1000");
                     goto n_input;
                 }

                 L=new int[n];

                 for(int i=0;i<n;i++)
                 {
                     L_input:
                     Console.Write("Length of stick {0}: ",i+1);
                     try{
                     L[i]= int.Parse(Console.ReadLine());
                      if(L[i]<1||L[i]>=1500) throw new Exception();
                     }
                     catch{
                         Console.WriteLine("Length of stick must be with in 1 to 1500");
                     goto L_input;
                     }
                 }
        }

        //static function to verify quadrilateral is non degenerate
        static bool isDegenQuadilateral(int a,int b,int c,int d)
        {
            if(a+b+c>d)
            if(b+c+d>a)
            if(c+d+a>b)
            if(d+a+b>c)
            return true;
            return false;
        }
         
    }
}
