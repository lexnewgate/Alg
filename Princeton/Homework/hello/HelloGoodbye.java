/* *****************************************************************************
 *  Name:              Ada Lovelace
 *  Coursera User ID:  123456
 *  Last modified:     October 16, 1842
 **************************************************************************** */

public class HelloGoodbye {
    public static void main(String[] args) {
        if (args == null || args.length != 2) {
            return;
        }
        String firstName = args[0];
        String secName = args[1];
        System.out.println(String.format("Hello %s and %s.", firstName, secName));
        System.out.println(String.format("Goodbye %s and %s.", secName, firstName));
    }
}
