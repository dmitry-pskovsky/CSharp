package view;

import events.IGridListener;
import events.KeyEventListener;
import events.KeyEventManager;
import model.Slab;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.lang.reflect.Array;
import java.util.ArrayList;

/**
 * Created by dimap on 10/13/2015.
 */
public class GridView extends JComponent implements IGridListener {

    public static final int WIDTH = 450;
    public static final int HEIGHT = 450;
    private int x = 0;
    private ArrayList<SlabView> slabs = new ArrayList<SlabView>();

    public GridView() {
        setSize(WIDTH, HEIGHT);
        setPreferredSize(new Dimension(WIDTH, HEIGHT));

        repaint();
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);

        DrawField(g);
        DrawEmptyCells(g);

        for (SlabView slab : slabs) {
           slab.draw(g);
        }

    }

    private void DrawField(Graphics g) {
        g.setColor(new Color(0xC7B696));
        g.fillRoundRect(0, 0, WIDTH, HEIGHT, 20, 20);
    }

    private void DrawEmptyCells(Graphics g2) {
        for (int i = 10; i < 450; i+= 110) {
            for (int j = 10; j < 450; j+= 110) {
                g2.setColor(new Color(0xCDC1C5));
                g2.fillRoundRect(i, j, 100, 100, 10, 10);
            }
        }
    }

    public void removeSlab(Point location) {
        for (int i = 0; i < slabs.size(); i++) {
            if(slabs.get(i).getLocation() == location)
                slabs.remove(i);
        }
    }

    public Point getCoordsOfLocation(Point location) {
        return new Point(10 + location.x * 110, 10 + location.y * 110);
    }

    @Override
    public void createSlab(Slab slab) {
        SlabView slabView = new SlabView();
        slabView.initialize(this, slab);
        slabs.add(slabView);

        repaint();
    }
}
