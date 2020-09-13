namespace FirstLib
{
    public class Class1
    {
        public int ret_val(int a, int b){
            int retval = a+10;
            for (int i = 0; i < b; i++) 
            {
            retval = retval + b;
            }
            return retval;
        }
    }
}