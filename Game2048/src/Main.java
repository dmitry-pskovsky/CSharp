import events.KeyEventManager;
import model.Grid;
import view.GridView;

import javax.swing.*;

/**
 * Created by dimap on 10/13/2015.
 */
public class Main {

    public Main() {
        JFrame jFrame = new JFrame("");
        jFrame.setSize(550, 530);
        jFrame.setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);
        jFrame.setVisible(true);


        GridView gridView = new GridView();
        jFrame.add(gridView);

        Grid grid = new Grid(gridView);
        grid.initialize();

        jFrame.addKeyListener(KeyEventManager.getInstance());

    }

    public static void main(String[] args) {
        new Main();
    }


}
