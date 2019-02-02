package model;

import events.IGridListener;
import events.KeyEventListener;
import events.KeyEventManager;

import java.awt.*;
import java.awt.font.NumericShaper;
import java.util.ArrayList;
import java.util.Random;

/**
 * Created by dimap on 10/15/2015.
 */
public class Grid implements KeyEventListener {

    Slab[][] slabs = new Slab[4][4];
    IGridListener iGridListener;
    private Slab slab;

    public Grid(IGridListener iGridListener) {
        this.iGridListener = iGridListener;
        KeyEventManager.getInstance().addKeyEventListener(this);
    }

    public void initialize() {
        createSlab();
    }

    private Slab createSlab() {
        ArrayList<Point> emptyLocations = new ArrayList<Point>();
        for (int i = 0; i < slabs.length; i++) {
            for (int j = 0; j < slabs[i].length; j++) {
                if (getSlabOnLocation(new Point(i, j)) == null) {
                    emptyLocations.add(new Point(i, j));
                }
            }
        }
        Random random = new Random();
        int rand = random.nextInt(emptyLocations.size());
        Point location = emptyLocations.get(rand);

        Slab slab = new Slab(this, location);
        addSlab(slab, location);
        iGridListener.createSlab(slab);

        return slab;
    }

    public void removeSlab(Point location) {
        slabs[location.x][location.y] = null;
    }

    public void addSlab(Slab slab, Point location) {
        if(slabs[location.x][location.y] != null) {
            slabs[location.x][location.y].remove();
            slabs[location.x][location.y] = null;
            slab.up();
            slabs[location.x][location.y] = slab;
        }
        else
        {
            slabs[location.x][location.y] = slab;
        }

    }

    private void initialie(IGridListener iGridListener) {
        this.iGridListener = iGridListener;
    }

    public Slab getSlabOnLocation(Point location) {
        return slabs[location.x][location.y];
    }

    public boolean isLocationEmpty(Point location, int value){
        if(location.x > slabs.length - 1 || location.y > slabs.length - 1)
            return false;
        if(location.x < 0 || location.y < 0)
            return false;
        Slab slab = getSlabOnLocation(location);
        if(slab != null) {
            if(slab.getValue() != value)
                return false;
        }
        return true;
    }

    @Override
    public void keyDownPressed() {
        for (int i = slabs.length - 2; i >= 0; i--) {
            for (int j = 0; j < slabs.length; j++) {
                if (slabs[j][i] != null)
                    slabs[j][i].keyDownPressed();
            }
        }
        createSlab();
        iGridListener.repaint();
    }

    @Override
    public void keyUpPressed() {
        for (int i = 1; i < slabs.length; i++) {
            for (int j = 0; j < slabs.length; j++) {
                if (slabs[j][i] != null)
                    slabs[j][i].keyUpPressed();
            }
        }
        createSlab();
        iGridListener.repaint();
    }

    @Override
    public void keyRightPressed() {
        for (int i = slabs.length - 2; i >= 0; i--) {
            for (int j = 0; j < slabs.length; j++) {
                if (slabs[i][j] != null)
                   slabs[i][j].keyRightPressed();
            }
        }
        createSlab();
        iGridListener.repaint();
    }

    @Override
    public void keyLeftPressed() {
        for (int i = 1; i < slabs.length; i++) {
            for (int j = 0; j < slabs.length; j++) {
                if (slabs[i][j] != null)
                    slabs[i][j].keyLeftPressed();
            }
        }
        createSlab();
        iGridListener.repaint();
    }
}
